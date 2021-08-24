using Detailing_Diary.Data;
using Detailing_Diary.Models;
using Detailing_Diary.Models.Bussiness;
using Detailing_Diary.Models.Users;
using Detailing_Diary.ViewModels.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext db;

        public ClaimsPrincipal User { get; private set; }

        public GarageService(ApplicationDbContext dbContext,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
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
            var owner = this.db.Owners.Where(o=>o.User.Id == userId).FirstOrDefault();
            Console.WriteLine("garageOWnerId: " + owner);

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
            return this.db.Garages.Where(g => g.Id == id).FirstOrDefault();
        }
    }
}
