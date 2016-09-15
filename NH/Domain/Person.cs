using System;
using System.Text;
using System.Collections.Generic;


namespace ContosoUniversity.NH.Domain {
    
    public class Person {
        public Person() { }
        public virtual int Id { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Firstname { get; set; }
        public virtual DateTime? Hiredate { get; set; }
        public virtual DateTime? Enrollmentdate { get; set; }
        public virtual string Discriminator { get; set; }
    }
}
