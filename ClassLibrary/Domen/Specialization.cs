using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Specialization
    {        
        public int Id { get; set; }        
        public string Title { get; set; }
        public int FreeCount { get; set; }        
        public int PayCount { get; set; }   
             
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }

        public virtual ICollection<SubjectSpecialization> SubjectSpecializations { get; set; }
        public Specialization()
        {
            SubjectSpecializations = new List<SubjectSpecialization>();
        }
    }
}
