using System.Collections.Generic;

namespace ClassLibrary
{
    public class Departament
    {       
        public int Id { get; set; }        
        public string Title { get; set; }

        public virtual ICollection<Specialization> Specializations { get; set; }
        public virtual ICollection<Professor> Professors { get; set; }

        public Departament()
        {
            Specializations = new List<Specialization>();
            Professors = new List<Professor>();
        }
    }
}
