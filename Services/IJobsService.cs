using Detailing_Diary.Areas.Jobs.ViewModels;
using Detailing_Diary.Models.Bussiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Services
{
   public interface IJobsService
    {

        Task<ActionResult<Job>> Create(JobInputModel job);
        Task<ActionResult<IEnumerable<Job>>> GetJobsByGarageId(Guid garageId);
        Task<ActionResult<Job>> GetJobByIdAsync(Guid jobId);
        void DeleteJob(Guid jobId);
        Task<ActionResult<Job>> EditJob(Guid Id ,JobInputModel job);
        Task<ActionResult> Rate(Guid jobId,int rate);
        
        


    }
}
