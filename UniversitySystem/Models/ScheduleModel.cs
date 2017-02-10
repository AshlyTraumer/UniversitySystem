using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ClassLibrary;

namespace UniversitySystem.Models
{
    public class ScheduleModel : ChangeModelBase
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Classroom { get; set; }

        [Required]
        public string Date { get; set; }
        

        public int SubjectId { get; set; }

        public int ProfessorId { get; set; }
    }
}