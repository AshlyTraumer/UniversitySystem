﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using UniversitySystem.Models.ReportModel;

namespace UniversitySystem.Report
{
    public class ProfessorQuery : IReport<ProfessorQueryModel>
    {
        //препод., факультет, количество экзаменов
        private readonly RepositoryContext _context;

        public ProfessorQuery(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<List<ProfessorQueryModel>> GetAsync()
        {
            return await _context.Professors.Select(t => new ProfessorQueryModel
                {
                    ProfessorName = t.Name,
                    DapartamentTitle = t.Departament.Title,
                    ExamCount = t.Schedules.Select(q => q.SubjectId).Count()
                })
                .OrderByDescending(x => x.ExamCount)
                .ToListAsync();
        }

        public List<ProfessorQueryModel> Get()
        {
            return  _context.Professors.Select(t => new ProfessorQueryModel
            {
                ProfessorName = t.Name,
                DapartamentTitle = t.Departament.Title,
                ExamCount = t.Schedules.Select(q => q.SubjectId).Count()
            })
                .OrderByDescending(x => x.ExamCount)
                .ToList();
        }
    }
}