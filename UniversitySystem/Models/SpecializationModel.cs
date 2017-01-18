using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class SpecializationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FreeCount { get; set; }
        public int PayCount { get; set; }

        public int DepartamentId { get; set; }
        public IEnumerable<Departament> Departaments { get; set; }
    }
}