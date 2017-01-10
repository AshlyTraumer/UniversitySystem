using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Departament
    {
        public int id { get; set; }
        public string title { get; set; }

        public virtual ICollection<Subject> subjects { get; set; }
        public Departament()
        {
            subjects = new List<Subject>();
        }
    }
}
