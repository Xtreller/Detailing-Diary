using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Detailing_Diary.Models.Bussiness
{
    public class Job
    {
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
        [ForeignKey("GarageId")]
        public Guid Garage { get; set; }
    }
}