using System;
using System.Collections.Generic;


namespace ClassLibrary
{
    public class Entrant: BaseEntity
    {
        public string Passport { get; set; }        
        public string FirstName { get; set; }        
        public string Name { get; set; }        
        public string LastName { get; set; }        
        public DateTime DateOfBirth { get; set; }        

        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }

        public virtual ICollection<Result> Results { get; set; }

        public Entrant()
        {
            Results = new List<Result>();
        }
    }
}
