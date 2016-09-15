using System;
using System.Text;
using System.Collections.Generic;


namespace ContosoUniversity.FluentNH.Domain {
    
    public class Enrollment {
        public virtual int Enrollmentid { get; set; }
        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
        public virtual int? Grade { get; set; }
    }
}
