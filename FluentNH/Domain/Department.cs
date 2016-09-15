using System;
using System.Text;
using System.Collections.Generic;


namespace ContosoUniversity.FluentNH.Domain {
    
    public class Department {
        public Department() { }
        public virtual int Departmentid { get; set; }
        public virtual Person Person { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Budget { get; set; }
        public virtual DateTime Startdate { get; set; }
        public virtual DateTime Rowversion { get; set; }
    }
}
