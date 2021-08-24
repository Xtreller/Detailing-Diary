using Detailing_Diary.Areas.Manager.Views.ViewModels;
using Detailing_Diary.Data;
using Detailing_Diary.Models;
using Detailing_Diary.Models.Bussiness;
using Detailing_Diary.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Detailing_Diary.Services
{
    public class ManagerService : IManagerService
    {
        private IHttpContextAccessor httpAccessor;
        private ApplicationDbContext db;
        private SignInManager<IdentityUser> signInManager;
        private UserManager<IdentityUser> userManager;
        private string userId;

        //public ClaimsPrincipal User { get; private set; }

        public ManagerService(ApplicationDbContext dbContext,
            UserManager<IdentityUser> userManager,
           IHttpContextAccessor httpContextAccessor,
            SignInManager<IdentityUser> signInManager)
        {
            this.httpAccessor = httpContextAccessor;
            this.db = dbContext;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userId = this.httpAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        }

        public ClaimsPrincipal User { get; private set; }

        public async Task<ActionResult<Garage>> AddEmployee(Guid garageId, string email)
        {
            //var ownerId = this.userManager.GetUserId(User);
            //Console.WriteLine(garageId);
            var employee =  await this.db.Employees.FindAsync(Guid.Parse("7e17d2c8-d6e3-430c-bbd0-a1e94c2352ed"));
            var garage = this.db.Garages.Where(g => g.Id == garageId).Include("Employees").FirstOrDefault();

            Console.WriteLine("AddEmployeeGarage: " + employee.Id);
            garage.Employees.Add(employee);
            employee.Garage = garage;
            this.db.SaveChanges();

            return garage;

        }

        public ICollection<Employee> Employees(Guid garageId)
        {
            var garage = this.db.Garages.Include("Employees").Where(g => g.Id == garageId).FirstOrDefault();
            Console.WriteLine(garage.Employees.FirstOrDefault());
            this.db.Employees.Where(e => e.Garage == garage).ToList();
            return garage.Employees;

        }

        public async Task<Garage> Garage(string userId)
        {

            var user = await this.db.Owners.FindAsync(Guid.Parse(this.userId));

            var garage = this.db.Garages.Where(g => g.Owner == user).FirstOrDefault();

            var employees = this.db.Employees.Where(e => e.Garage == garage).ToList();
            var view = new GarageViewModel()
            {
                Garage = garage,
                Employees = employees

            };
            return garage;
        }

        public async Task<ActionResult<Garage>> RemoveEmployee(Guid EmployeeId)
        {
            Console.WriteLine(EmployeeId);
            var user = await this.db.Owners.FindAsync(this.userId);

            var garage = await this.db.Garages.Where(g => g.Owner == user).FirstOrDefaultAsync();
            var employee = await this.db.Employees.FindAsync(EmployeeId);


            garage.Employees.ToList().Remove(employee);
            await this.db.SaveChangesAsync();
            return garage;
        }
    }
}
