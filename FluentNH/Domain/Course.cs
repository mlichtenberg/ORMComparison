using System;
using System.Text;
using System.Collections.Generic;


namespace ContosoUniversity.FluentNH.Domain {
    
    public class Course {
        public Course() { }
        public virtual int Courseid { get; set; }
        public virtual Department Department { get; set; }
        public virtual string Title { get; set; }
        public virtual int Credits { get; set; }
    }
}
