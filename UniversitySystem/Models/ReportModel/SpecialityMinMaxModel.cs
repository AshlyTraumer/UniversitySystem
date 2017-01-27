namespace UniversitySystem.Models.ReportModel
{
    public class SpecialityMinMaxModel
    {
        //ид, название, мин балл, макс балл
        public int Id { get; set; }
        public string Title { get; set; }
        public int MinPoint { get; set; }
        public int MaxPoint { get; set; } 
    }
}