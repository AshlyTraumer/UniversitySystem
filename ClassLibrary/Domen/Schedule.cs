using System;

namespace ClassLibrary
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Classroom { get; set; }
        public DateTime Date { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }        
    }
}
