namespace ClassLibrary
{
    public class SubjectSpecialization : BaseEntity
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
