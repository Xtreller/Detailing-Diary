using Detailing_Diary.Areas.Manager.Views.ViewModels;
using Detailing_Diary.Models.Bussiness;
using Detailing_Diary.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Services
{
   public interface IManagerService
    {
        
        Task<Garage> Garage(string garageId);
        ICollection<Employee> Employees(Guid garageId);
        Task<ActionResult<Garage>> AddEmployee(Guid garageId,string email);
        Task<ActionResult<Garage>> RemoveEmployee(Guid EmployeeId);


    }
}
