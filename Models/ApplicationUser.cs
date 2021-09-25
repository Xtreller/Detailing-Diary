using Detailing_Diary.Models.Bussiness;
using Detailing_Diary.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        //[Required]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
        //public virtual Employee Employee { get; set; }
        //public virtual Client Client { get; set; }
        //public virtual Owner Owner { get; set; }
        public virtual Garage Garage { get; set; }
    }
}
