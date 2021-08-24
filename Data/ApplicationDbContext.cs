using Detailing_Diary.Models;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Garage>().HasMany(g => g.Jobs).WithOne(j => j.Garage).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Garage>().HasMany(g => g.Employees).WithOne(j => j.Garage).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Employee>().HasOne(e => e.Garage).WithMany(g => g.Employees).OnDelete(DeleteBehavior.Cascade);

            // Configure Student & StudentAddress entity
            //modelBuilder.Entity<Owner>().HasOne(o => o.Garage).WithOne(g => g.Owner).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Review> Reviews{ get; set; }



    }
}
