using Detailing_Diary.Areas.Jobs.ViewModels;
using Detailing_Diary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Areas.Jobs.Controllers
{
    public class JobsController : Controller
    {
        private IJobsService jobsService;

        public JobsController(IJobsService jobsService)
        {
            this.jobsService = jobsService;
        }
        // GET: JobsController
        [HttpGet("CreateJob/{id}")]
        [Area("Jobs")]
        public ActionResult CreateJob()
        {
            return View();
        }
        [HttpPost("CreateJob/{id}")]
        public ActionResult CreateJob(Guid id, JobInputModel input)
        {
            input.garageId = id;
            this.jobsService.Create(input);
            return RedirectToAction("Details", "Garage", new { id = id });
        }


        // GET: JobsController/Details/5
        [Area("Jobs")]
        [HttpGet("Jobs/Details/{id}")]
        public ActionResult Details(Guid id)
        {
            ViewBag.job = this.jobsService.GetJobByIdAsync(id).Result.Value;

            return View();
        }


        // GET: JobsController/Edit/5
        [Area("Jobs")]
        [HttpGet("Jobs/Edit/{id}")]
        public ActionResult Edit(Guid id)
        {
            ViewBag.job = this.jobsService.GetJobByIdAsync(id).Result.Value;
            return View("EditJob");
        }

        // POST: JobsController/Edit/5
        [HttpPost("Jobs/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, JobInputModel input)
        {
            Console.WriteLine(input.Employee);
            this.jobsService.EditJob(id, input);
            return RedirectToAction("Details", "Jobs", new { id = id });
        }



        // POST: JobsController/Delete/5
        [HttpPost("Jobs/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            this.jobsService.DeleteJob(id);

            return RedirectToAction("Garages", "Garage", new { id = id });

        }
    }
}
