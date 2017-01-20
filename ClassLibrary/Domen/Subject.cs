using System.Collections.Generic;

namespace ClassLibrary
{
    public class Subject : BaseEntity
    {        
        public string Title { get; set; }
        public string Form { get; set; }

        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<SubjectSpecialization> SubjectSpecializations{ get; set; }
        
        public virtual ICollection<Schedule> Schedules { get; set; }

        public Subject()
        {
            Results = new List<Result>();
            SubjectSpecializations = new List<SubjectSpecialization>();
            Schedules = new List<Schedule>();
        }
    }
}
