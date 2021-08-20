using Detailing_Diary.Data;
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
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext db;

        public ClaimsPrincipal User { get; private set; }

        public GarageService(ApplicationDbContext dbContext, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = dbContext;
        }

        public async Task<ActionResult<Garage>> AddGarageAsync(GarageInputModel garage)
        {
            //var user = await userManager.GetUserAsync();
            var newGarage = new Garage()
            {
                Id = Guid.NewGuid(),
                Name = garage.Name,
                Town = garage.Town,
                Address = garage.Address,
                OwnerId = new Guid("28edac52-c09f-48fc-8490-9b4a7ff535d0")
            };
             this.db.Garages.Add(newGarage);
             this.db.SaveChanges();
            Console.WriteLine("here " + newGarage.ToString());

            return this.GetGarage(newGarage.Id);
        }

        public ActionResult<Garage> DeleteGarage(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Garage> EditGarage(GarageInputModel garage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Garage> GetGarages()
        {
            return this.db.Garages.ToList();
        }

        public ActionResult<Garage> GetGarage(Guid id)
        {
            return this.db.Garages.Where(g => g.Id == id).FirstOrDefault();
        }
    }
}
