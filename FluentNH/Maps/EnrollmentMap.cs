using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using ContosoUniversity.FluentNH.Domain; 

namespace ContosoUniversity.FluentNH.Maps {
    
    
    public class EnrollmentMap : ClassMap<Enrollment> {
        
        public EnrollmentMap() {
			Table("Enrollment");
			LazyLoad();
			Id(x => x.Enrollmentid).GeneratedBy.Identity().Column("EnrollmentID");
			References(x => x.Course).Column("CourseID");
			References(x => x.Person).Column("StudentID");
			Map(x => x.Grade).Column("Grade");
        }
    }
}
