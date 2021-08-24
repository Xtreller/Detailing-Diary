using Detailing_Diary.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Models.Bussiness
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public virtual IdentityUser Reviewer{ get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
