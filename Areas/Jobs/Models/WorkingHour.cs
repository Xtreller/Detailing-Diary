using System;

namespace Detailing_Diary.Models.Bussiness
{
    public class WorkingHours
    {
        public DayOfWeek Day { get; set; }
        public DateTime Start{ get; set; }
        public DateTime End{ get; set; }
    }
}