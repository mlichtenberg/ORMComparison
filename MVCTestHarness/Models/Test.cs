using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Test
    {
        [Display(Name = "Iterations")]
        public int Iterations { get; set; }

        [Display(Name = "Operation")]
        public string Operation { get; set; }    // Select, Insert, Update, Delete

        [Display(Name = "Library")]
        public string Library { get; set; } // EF, DAL

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Elapsed")]
        public double Elapsed { get { return (this.EndTime - this.StartTime).TotalSeconds; } }

        public Test()
        {

        }

        public Test(string library,string operation, int iterations, DateTime startTime)
        {
            Library = library;
            Operation = operation;
            Iterations = iterations;
            StartTime = startTime;
        }
    }
}
