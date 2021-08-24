using Detailing_Diary.Models.Bussiness;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Models.Users
{
    public class Owner 
    {
        [Key]
        public Guid Id { get; set; }
        public IdentityUser User { get; set; }
        public virtual  Garage Garage { get; set; }

    }
}
