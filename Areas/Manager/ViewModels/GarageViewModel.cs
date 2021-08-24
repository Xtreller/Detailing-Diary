using Detailing_Diary.Models.Bussiness;
using Detailing_Diary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Areas.Manager.Views.ViewModels
{
    public class GarageViewModel
    {
        public Garage Garage { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
