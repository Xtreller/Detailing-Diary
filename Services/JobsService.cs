using Detailing_Diary.Areas.Jobs.ViewModels;
using Detailing_Diary.Data;
using Detailing_Diary.Models;
using Detailing_Diary.Models.Bussiness;
using Detailing_Diary.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Services
{
    public class JobsService : IJobsService
    {
        private ApplicationDbContext db;
        private SignInManager<IdentityUser> signInManager;
        private UserManager<IdentityUser> userManager;
        private IGarageService garageService;

        public JobsService(ApplicationDbContext dbContext,
            IGarageService garageService,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.db = dbContext;
            this.signInManager = signInManager;
            this.garageService = garageService;
        }
        public async Task<ActionResult<Job>> Create(JobInputModel job)
        {
            TimeSpan ts = job.TimeSpan;
            var garage = this.db.Garages.Find(job.garageId);
            garage.JobsCount = garage.JobsCount + 1;
            var employee = this.db.Employees.Where(e => e.Garage == garage).Where(e => e.FirstName == job.Employee).FirstOrDefault();
            var newJob = new Job()
            {
                DetailName = job.DetailName,
                Date = job.Date,
                TimeSpan = job.TimeSpan,
                Type = job.Type,
                Garage = garage,
                Employee = employee,
                ClientFirstName = job.ClientFirstName,
                ClientLastName = job.ClientLastName,
                ClientCar = job.ClientCar

            };

            this.db.Jobs.Add(newJob);
            this.db.SaveChanges();
            return await this.GetJobByIdAsync(newJob.Id);

        }

        public void DeleteJob(Guid id)
        {
            var job = this.db.Jobs.Find(id);
            this.db.Jobs.Remove(job);
            this.db.SaveChanges();
        }


        public async Task<ActionResult<Job>> EditJob(Guid Id, JobInputModel job)
        {


            var jobToUpdate = this.db.Jobs.Find(Id);
            var employee = this.db.Employees.Find(job.Employee);
            Console.WriteLine("employee: ");

            if (employee == null)
            {
                Console.WriteLine("Employee not Found");
            }
            jobToUpdate.DetailName = job.DetailName;
            jobToUpdate.Date = job.Date;
            jobToUpdate.TimeSpan = job.TimeSpan;
            jobToUpdate.Type = job.Type;
            jobToUpdate.Employee = employee;
            jobToUpdate.ClientFirstName = job.ClientFirstName;
            jobToUpdate.ClientLastName = job.ClientLastName;
            jobToUpdate.ClientCar = job.ClientCar;
            this.db.SaveChanges();
            return await this.GetJobByIdAsync(jobToUpdate.Id);
        }

        public async Task<ActionResult<Job>> GetJobByIdAsync(Guid jobId)
        {

            return await this.db.Jobs.Where(g => g.Id == jobId).FirstOrDefaultAsync();
        }

        public async Task<ActionResult<IEnumerable<Job>>> GetJobsByGarageId(Guid garageId)
        {
            return await this.db.Jobs.Where(j => j.Garage.Id == garageId).ToListAsync();
        }


        public Task<ActionResult> Rate(Guid jobId, int rate)
        {
            throw new NotImplementedException();
        }
    }
}
