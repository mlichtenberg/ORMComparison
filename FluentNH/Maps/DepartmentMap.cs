using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using ContosoUniversity.FluentNH.Domain; 

namespace ContosoUniversity.FluentNH.Maps {
    
    
    public class DepartmentMap : ClassMap<Department> {
        
        public DepartmentMap() {
			Table("Department");
			LazyLoad();
			Id(x => x.Departmentid).GeneratedBy.Identity().Column("DepartmentID");
			References(x => x.Person).Column("InstructorID");
			Map(x => x.Name).Column("Name");
			Map(x => x.Budget).Column("Budget").Not.Nullable();
			Map(x => x.Startdate).Column("StartDate").Not.Nullable();
			Map(x => x.Rowversion).Column("RowVersion").Not.Nullable();
        }
    }
}
