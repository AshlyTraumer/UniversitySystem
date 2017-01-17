using System.ComponentModel;


namespace ClassLibrary
{
    // Mark of enrollment.
    public enum RegistrationStatus
    {
        [Description ("Бюджетное")]
        OnFree=1,
        [Description("Платное")]
        OnPaid =2,
        [Description("Не зачислен")]
        None = 3
    }

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
