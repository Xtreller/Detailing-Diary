using Detailing_Diary.Areas.Jobs.ViewModels;
using Detailing_Diary.Data;
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
        private object userManager;
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
            var newJob = new Job()
            {
                DetailName = job.DetailName,
                Date = DateTime.Now,
                TimeSpan = job.TimeSpan,
                Type = job.Type,
                Garage = job.garageId,
                ClientFirstName = job.ClientFirstName,
                ClientLastName = job.ClientLastName,
                ClientCar = job.ClientCar


            };

            this.db.Jobs.Add(newJob);
            this.db.SaveChanges();
            return await this.GetJobByIdAsync(newJob.Id);

        }

        public Task<ActionResult> DeleteJob(Guid jobId)
        {
            throw new NotImplementedException();
        }


        public Task<ActionResult> EditJob(JobInputModel job)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Job>> GetJobByIdAsync(Guid jobId)
        {
            return await this.db.Jobs.Where(g => g.Id == jobId).FirstOrDefaultAsync();
        }

        public async Task<ActionResult<IEnumerable<Job>>> GetJobsByGarageId(Guid garageId)
        {
            return await this.db.Jobs.Where(j => j.Garage == garageId).ToListAsync();
        }


        public Task<ActionResult> Rate(Guid jobId, int rate)
        {
            throw new NotImplementedException();
        }
    }
}
