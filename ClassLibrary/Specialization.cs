using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Specialization
    {
        public int id { get; set; }
        public string title { get; set; }
        public Departament departament { get; set; }
        public float freeCount { get; set; }
        public float payCount { get; set; }

        public virtual ICollection<Subject> subjects { get; set; }
        public Specialization()
        {
            subjects = new List<Subject>();

            
        }
    }
}
