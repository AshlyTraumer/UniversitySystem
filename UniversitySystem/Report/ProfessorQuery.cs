using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using UniversitySystem.Models.ReportModel;

namespace UniversitySystem.Report
{
    public class ProfessorQuery 
    {
        //препод., факультет, количество экзаменов
        private readonly RepositoryContext _context;

        public ProfessorQuery(RepositoryContext context)
        {
            _context = context;
        }

        public List<ProfessorQueryModel> Get() => _context.Professors.Select(t => new ProfessorQueryModel
            {
                ProfessorName = t.Name,
                DapartamentTitle = t.Departament.Title,
                ExamCount = t.Schedules.Select(q => q.SubjectId).Count()
            })
            .OrderByDescending(x => x.ExamCount)
            .ToList();
    }
}