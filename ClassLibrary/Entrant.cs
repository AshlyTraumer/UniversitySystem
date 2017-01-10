using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Entrant
    {
        public int id { get; set; }
        public string passport { get; set; }
        public string firstName { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public char sex { get; set; }

        public virtual List<Result> results { get; set; }
        public Entrant()
        {
            results = new List<Result>();
        }
    }
}
