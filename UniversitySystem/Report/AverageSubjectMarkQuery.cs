﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using UniversitySystem.Models.ReportModel;

namespace UniversitySystem.Report
{
    public class AverageSubjectMarkQuery : IReport<AverageSubjectMarkModel>
    {
        private readonly RepositoryContext _context;

        public AverageSubjectMarkQuery(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<List<AverageSubjectMarkModel>> GetAsync()
        {
            return await _context.Subjects.Select(t => new AverageSubjectMarkModel
            {
                Id = t.Id,
                Title = t.Title,
                Points = t.Results.Select(x => x.Points).Average()
            })
            .ToListAsync();
        }

        public List<AverageSubjectMarkModel> Get()
        {
            return  _context.Subjects.Select(t => new AverageSubjectMarkModel
            {
                Id = t.Id,
                Title = t.Title,
                Points = t.Results.Select(x => x.Points).Average()
            })
            .ToList();
        }
    }
}