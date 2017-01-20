namespace ClassLibrary
{
    public class Result : BaseEntity
    {       
        public int Points { get; set; }

        public int EntrantId { get; set; }
        public Entrant Entrant { get; set; }
           
        public int SubjectId { get; set; }     
        public Subject Subject { get; set; }              
    }
}
