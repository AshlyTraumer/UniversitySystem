using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class ResultModel : ChangeModelBase
    {
        public int Points { get; set; }
        public string EntrantName { get; set; }
        public int SubjectId { get; set; }
    }
}