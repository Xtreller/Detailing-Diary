using Detailing_Diary.Services;
using Detailing_Diary.ViewModels.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Controllers.Garages
{
    public class GarageController : Controller
    {
        private IGarageService garageService;
        private IJobsService jobsService;

        public GarageController(IGarageService garageService, IJobsService jobsService)
        {
            this.garageService = garageService;
            this.jobsService = jobsService;
        }
        public ActionResult Garages()       
        {
            ViewBag.Garages =  this.garageService.GetGarages();
            return View();
        }

        // GET: GarageController/Details/5
        public ActionResult AddGarage(int id)
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddGarage(GarageInputModel garage)
        {
            this.garageService.AddGarageAsync(garage);
            return RedirectToAction("Garages");
        }


        [HttpGet("Garage/Details/{id}")]
        public ActionResult GarageDetails(Guid Id)
        {
            Console.WriteLine(Id);
            ViewBag.Jobs = this.jobsService.GetJobsByGarageId(Id).Result.Value;
            ViewBag.GarageDetails = this.garageService.GetGarage(Id).Value;
            return View();
        }
        // POST: GarageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GarageController/Edit/5
        [HttpGet("Garage/Edit/{id}")]
        public ActionResult Edit(Guid id)
        {

            ViewBag.garage = this.garageService.GetGarage(id).Value;
            return View("EditGarage");
        }

        // POST: GarageController/Edit/5
        [HttpPost("Garage/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditGarage(Guid id, GarageInputModel garage)
        {
            garage.Id = id;
            Console.WriteLine("garage Edit");
            this.garageService.EditGarage(garage);
            return RedirectToAction("Details", new { id = id });
        }

        // GET: GarageController/Delete/5
        [HttpPost("Garage/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            this.garageService.DeleteGarage(id);
            return RedirectToAction("Garages");
        }

        
    
    }
}
