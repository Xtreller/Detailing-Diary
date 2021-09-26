using Detailing_Diary.Data;
using Detailing_Diary.Models;
using Detailing_Diary.Models.Bussiness;
using Detailing_Diary.Models.Users;
using Detailing_Diary.ViewModels.Input;
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
    public class GarageService : IGarageService
    {
        private readonly IHttpContextAccessor httpAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext db;

        public ClaimsPrincipal User { get; private set; }

        public GarageService(ApplicationDbContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {

            this.httpAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = dbContext;
        }

        public async Task<ActionResult<Garage>> AddGarageAsync(GarageInputModel garage)
        {
            var userId = this.httpAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Console.WriteLine(userId);
            var user = this.db.Users.Where(u=>u.Id == Guid.Parse(userId)).FirstOrDefault();
            Console.WriteLine("test");
            var owner = this.db.Owners.Where(o => o.User.Id == user.Id).FirstOrDefault();
            Console.WriteLine("test2");
            Console.WriteLine(user.FirstName);
            Console.WriteLine("test3");
            if (owner == null) 
            {
                owner = new Owner
                {
                    Id = user.Id,
                    User = user 
                };
                 this.db.Owners.Add(owner);
                Console.WriteLine(owner.Id);
            }
            
            
            Console.WriteLine("userId: " + owner.Id);


            var newGarage = new Garage()
            {
                Id = Guid.NewGuid(),
                Name = garage.Name,
                Town = garage.Town,
                Address = garage.Address,
                Owner = owner,
                CreatedAt = DateTime.Now
            };
            await this.db.Garages.AddAsync(newGarage);
            this.db.SaveChanges();

            return this.GetGarage(newGarage.Id);
        }

        public void DeleteGarage(Guid id)
        {
            var garage = this.db.Garages.Find(id);
            this.db.Garages.Remove(garage);
            this.db.SaveChanges();
        }

        public ActionResult<Garage> EditGarage(GarageInputModel garage)
        {
            var garageToUpdate = this.db.Garages.Where(g => g.Id == garage.Id).FirstOrDefault();

            garageToUpdate.Name = garage.Name;
            garageToUpdate.Town = garage.Town;
            garageToUpdate.Address = garage.Address;

            this.db.SaveChanges();
            return this.GetGarage(garage.Id);
        }

        public IEnumerable<Garage> GetGarages()
        {
            return this.db.Garages.ToList().OrderByDescending(g => g.CreatedAt);

        }

        public ActionResult<Garage> GetGarage(Guid id)
        {
            var garage = this.db.Garages.Where(g => g.Id == id).Include("Owner").FirstOrDefault();
            Console.WriteLine(garage.Owner);
            return garage;
        }
    }
}
