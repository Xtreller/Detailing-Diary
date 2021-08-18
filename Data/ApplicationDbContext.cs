using Detailing_Diary.Models.Bussiness;
using Detailing_Diary.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Detailing_Diary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Owner> Owners{ get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<Garage> Garages{ get; set; }
        public DbSet<Job> Jobs{ get; set; }

        

    }
}
