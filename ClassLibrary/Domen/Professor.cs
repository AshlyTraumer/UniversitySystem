using System.Collections.Generic;

namespace ClassLibrary
{
    public class Professor : BaseEntity
    {         
        public string Name { get; set; }

        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }
        public int ExamCount { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }

        public Professor()
        {
            Schedules = new List<Schedule>();
        }
    }
}
