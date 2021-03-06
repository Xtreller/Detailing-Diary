using Detailing_Diary.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Models.Bussiness
{
    public class Garage
    {
     
        public Garage()
        {
            Rating = 0;
            JobsCount = 0;
            Jobs = new List<Job>();
            Employees = new List<Employee>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        [ForeignKey("OwnerId")]
        public virtual Owner Owner { get; set; }

        public int Rating { get; set; }
        public int JobsCount { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
