using System;
using System.ComponentModel.DataAnnotations;

namespace Detailing_Diary.Models.Bussiness
{
    public class Job
    {
        [Key]
        public Guid Id { get; set; }

    }
}