using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class ScheduleViewModel : ChangeModelBase
    {
        public string Classroom { get; set; }
        public DateTime Date { get; set; }

        public string SubjectTitle { get; set; }
        public string ProfessorName { get; set; }
       
    }
}