using System.Collections.Generic;

namespace ClassLibrary
{
    public class Specialization : BaseEntity
    {
        public string Title { get; set; }
        public int FreeCount { get; set; }
        public int PayCount { get; set; }

        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }

        public virtual ICollection<SubjectSpecialization> SubjectsSpecialization { get; set; }

        public Specialization()
        {
            SubjectsSpecialization = new List<SubjectSpecialization>();
        }
    }
}
