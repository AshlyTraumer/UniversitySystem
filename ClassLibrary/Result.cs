using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Result
    {
        public int id { get; set; }
        public Entrant entrant { get; set; }
        public Subject subject { get; set; }
        public int points { get; set; }        
    }
}
