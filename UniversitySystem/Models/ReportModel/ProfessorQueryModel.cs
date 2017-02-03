namespace UniversitySystem.Models.ReportModel
{
    public class ProfessorQueryModel : BaseReportModel
    {
        //препод., факультет, количество экзаменов
        public string ProfessorName { get; set; }
        public string DapartamentTitle { get; set; }
        public int ExamCount { get; set; }
    }
}