using Detailing_Diary.Models.Bussiness;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Models.Users
{
    public class Owner : IdentityUser
    {
        
        public Employee[] Employees { get; set; }

    }
}
