using Detailing_Diary.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Employee Employee { get; set; }
        public virtual Client Client { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
