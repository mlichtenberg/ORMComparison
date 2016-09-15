using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using ContosoUniversity.FluentNH.Domain; 

namespace ContosoUniversity.FluentNH.Maps {
    
    
    public class PersonMap : ClassMap<Person> {
        
        public PersonMap() {
			Table("Person");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			Map(x => x.Lastname).Column("LastName").Not.Nullable();
			Map(x => x.Firstname).Column("FirstName").Not.Nullable();
			Map(x => x.Hiredate).Column("HireDate");
			Map(x => x.Enrollmentdate).Column("EnrollmentDate");
			Map(x => x.Discriminator).Column("Discriminator").Not.Nullable();
        }
    }
}
