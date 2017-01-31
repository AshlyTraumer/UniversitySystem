using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class EntrantViewMapperModel : ChangeModelBase
    {
        public string Passport { get; set; }
       // public string FirstName { get; set; }
        public string Name { get; set; }
       // public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ResultStatus { get; set; }
    }
}