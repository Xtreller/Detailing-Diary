using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Models.Users
{
    public class Employee : IdentityUser
    {
        public Guid GarageId { get; set; }
        public Guid EmployeerId { get; set; }
        public string Rating { get; set; }
    }
}
