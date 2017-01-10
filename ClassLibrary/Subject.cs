using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Subject
    {
        public int id { get; set; }
        public string title { get; set; }
        public string form { get; set; }

        public virtual List<Result> results { get; set; }
        public Subject()
        {
            results = new List<Result>();
        }
    }
}
