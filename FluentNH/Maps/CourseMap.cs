using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using ContosoUniversity.FluentNH.Domain; 

namespace ContosoUniversity.FluentNH.Maps {
    
    
    public class CourseMap : ClassMap<Course> {
        
        public CourseMap() {
			Table("Course");
			LazyLoad();
			Id(x => x.Courseid).GeneratedBy.Identity().Column("CourseID");
			References(x => x.Department).Column("DepartmentID");
			Map(x => x.Title).Column("Title");
			Map(x => x.Credits).Column("Credits").Not.Nullable();
        }
    }
}
