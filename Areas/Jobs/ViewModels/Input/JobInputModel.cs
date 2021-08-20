using Detailing_Diary.Models.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Areas.Jobs.ViewModels
{
    public class JobInputModel
    {
        public string Name { get; set; }
        public string DetailName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int Rating { get; set; }
        public string Type { get; set; }
        public Guid garageId { get; set; }
    }
}
