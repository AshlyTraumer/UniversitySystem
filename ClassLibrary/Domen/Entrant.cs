﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{   
    public class Entrant
    {
        public int Id { get; set; }
        public string Passport { get; set; }        
        public string FirstName { get; set; }        
        public string Name { get; set; }        
        public string LastName { get; set; }        
        public DateTime DateOfBirth { get; set; }        

        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }

        public virtual ICollection<Result> Results { get; set; }
        public Entrant()
        {
            Results = new List<Result>();
        }
    }
}
