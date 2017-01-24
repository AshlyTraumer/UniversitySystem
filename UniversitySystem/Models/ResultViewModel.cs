using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class ResultViewModel
    {
        public int Id { get; set; }
        public string EntrantName { get; set; }
        public string SubjectTitle { get; set; }
        public int Points { get; set; }
    }
}