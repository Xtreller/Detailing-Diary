using Detailing_Diary.Models.Bussiness;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Models.Users
{
    public class Client 
    {
        public Client()
        {
            Favorites = new List<Garage>();
        }
        [Key]
        public Guid Id { get; set; }
        public IdentityUser User { get; set; }
        public ICollection<Garage> Favorites { get; set; }
    }
}
