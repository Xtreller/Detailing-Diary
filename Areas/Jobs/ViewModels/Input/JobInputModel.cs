using Detailing_Diary.Models.Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Areas.Jobs.ViewModels
{
    public class JobInputModel
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string DetailName { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int Rating { get; set; }

        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientCar { get; set; }
        public string Employee { get; set; }
        public Guid garageId { get; set; }
    }
}
