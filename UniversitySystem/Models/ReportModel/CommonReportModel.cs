using System.Collections.Generic;

namespace UniversitySystem.Models.ReportModel
{
    public class CommonReportModel
    {
        public List<AverageSubjectMarkModel> AverageSubjectMarkModels { get; set; }
        public List<ProfessorQueryModel> ProfessorQueryModels { get; set; }
        public List<TopEntrantModel> TopEntrantModels { get; set; }
        public SpecialityMinMaxModel SpecialityMinMaxModel { get; set; }
    }
}