namespace UniversitySystem.Models.ReportModel
{
    public class AverageSubjectMarkModel : BaseReportModel
    {
        //ид, название, ср. оценка
        public int Id { get; set; }
        public string Title { get; set; }
        public double Points { get; set; }
    }
}