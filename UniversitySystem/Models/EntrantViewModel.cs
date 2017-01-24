using System;
using ClassLibrary;

namespace UniversitySystem.Models
{
    public class EntrantViewModel : ChangeModelBase
    {
        public string Passport { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ResultStatus { get; set; }
    }
}