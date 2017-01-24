using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;

namespace UniversitySystem.Models
{
    public class EntrantModel : ChangeModelBase
    {
        public string Passport { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int SpecializationId { get; set; }
    }
}