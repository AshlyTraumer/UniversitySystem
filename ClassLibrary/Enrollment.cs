using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   // struct RegistrationStatus 
    class Enrollment
    {
        public int id { get; set; }
        public Entrant entrant { get; set; }
        public int points { get; set; }
        public Specialization specialization { get; set; }
        //public RegistrationStatus registrationStatus { get; set; }
    }
}
