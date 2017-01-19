using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Form { get; set; }

        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<SubjectSpecialization> SubjectSpecializations{ get; set; }

        // public virtual ICollection<Specialization> Specializations { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public Subject()
        {
            Results = new List<Result>();
            SubjectSpecializations = new List<SubjectSpecialization>();
           // Specializations = new List<Specialization>();
            Schedules = new List<Schedule>();
        }
    }
}
