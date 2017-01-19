namespace ClassLibrary
{
    public class Result
    {        
        public int Id { get; set; }
        public int Points { get; set; }

        public int EntrantId { get; set; }
        public Entrant Entrant { get; set; }
           
        public int SubjectId { get; set; }     
        public Subject Subject { get; set; }              
    }
}
