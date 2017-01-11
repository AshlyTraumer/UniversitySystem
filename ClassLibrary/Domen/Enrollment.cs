namespace ClassLibrary
{
    // Mark of enrollment.
    public enum RegistrationStatus { OnFree, OnPaid, None }

    public class Enrollment
    {        
        public int Id { get; set; }
        public int Points { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }

        public int EntrantId { get; set; }
        public Entrant Entrant { get; set; }     
               
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }        
    }
}
