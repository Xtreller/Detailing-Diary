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

        public GarageController(IGarageService garageService)
        {
            this.garageService = garageService;
        }
        // GET: GarageController
        public ActionResult Garages()
        {
            ViewBag.Garages = this.garageService.GetGarages();
        
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
             this.garageService.AddGarageAsync(garage) ;
            return RedirectToAction("Garages");
        }

        // GET: GarageController/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet("Garage/Details/{id}")]
        public ActionResult GarageDetails(Guid Id) {
            Console.WriteLine(Id);
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GarageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: GarageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GarageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
