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
        private SignInManager<ApplicationUser> signInManager;
        private UserManager<ApplicationUser> userManager;
        private string userId;

        //public ClaimsPrincipal User { get; private set; }

        public ManagerService(ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
           IHttpContextAccessor httpContextAccessor,
            SignInManager<ApplicationUser> signInManager)
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
            var user = await this.db.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            //var employee = await this.db.Employees.Add();
            //var garage = 
            if (user == null) 
            {
                Console.WriteLine($"Employee {garageId} Not Found!");
                return null;
            }
            var garage = await this.db.Garages.FindAsync(garageId);
            if (garage == null)
            {
                Console.WriteLine($"Garage {garageId} Not Found!");
                return null;
            };


            Employee newEmployee = new Employee()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Garage = garage
             };
            garage.Employees.Add(newEmployee);
            this.db.Employees.Add(newEmployee);
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
            var user = await this.db.Owners.FindAsync(Guid.Parse(this.userId));

            Console.WriteLine("user" + user == null);
            var garage = await this.db.Garages.Where(g => g.Owner == user).FirstOrDefaultAsync();
            Console.WriteLine("garage: " + garage.Id);
            var employee = await this.db.Employees.FindAsync(EmployeeId);
            Console.WriteLine("employee: " + employee.Id);
            

            garage.Employees.Remove(employee);
            this.db.SaveChanges();

            return garage;
        }
    }
}
