using Detailing_Diary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Areas.Manager.Controllers
{
    public class ManagerController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private IManagerService managerService;

        public ManagerController(IManagerService managerService, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.managerService = managerService;

        }
        public IActionResult Index()
        {
            return View();
        }
        [Area("Manager")]
        [HttpGet("Manager/MyGarage/{id}")]
        public IActionResult MyGarage(string userId)
        {

            var garage = this.managerService.Garage(userId).Result;
            //Console.WriteLine(garage.Employees.First().FirstName);

            ViewBag.Garage = garage;
            ViewBag.Employees = this.managerService.Employees(garage.Id);
            return View();
        }
        //[Area("Manager")]
        //[HttpGet("Manager/AddEmployee/{id}")]
        //public async Task<IActionResult> AddEmployee()
        //{

        //    return View();
        //}
        [Area("Manager")]
        [HttpPost("Manager/AddEmployee/{id}")]
        public async Task<IActionResult> PostAddEmployee(Guid id, string employeeEmail)
        {
            Console.WriteLine("managerController: " + employeeEmail);
            var userId = userManager.GetUserId(User);

            await this.managerService.AddEmployee(id, employeeEmail);
            return RedirectToAction("MyGarage", "Manager", new { id = userId });
        }

    }
}
