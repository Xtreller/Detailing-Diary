using Detailing_Diary.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Detailing_Diary.Models.Bussiness
{
    public class Job
    {
        public Job()
        {
            Rating = 0;

        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DetailName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int Rating { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientCar { get; set; }
        public string Type { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Garage Garage { get; set; }
    }
}