using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Professor
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public Professor()
        {
            Schedules = new List<Schedule>();
        }
    }
}
