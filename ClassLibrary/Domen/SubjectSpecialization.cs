using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SubjectSpecialization
    {
        public int Id { get; set; }        

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
