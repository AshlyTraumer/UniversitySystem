using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class ProfessorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartamentId{ get; set; }
    }
}