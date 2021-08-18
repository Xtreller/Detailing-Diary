using Detailing_Diary.Models.Bussiness;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Models.Users
{
    public class Client : IdentityUser
    {
        public Garage[] Favorite { get; set; }
    }
}
