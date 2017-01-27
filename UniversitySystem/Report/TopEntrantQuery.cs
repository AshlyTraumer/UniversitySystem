using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using UniversitySystem.Models.ReportModel;
using static System.String;

namespace UniversitySystem.Report
{
    public class TopEntrantQuery 
    {
        private readonly RepositoryContext _context;

        public TopEntrantQuery(RepositoryContext context)
        {
            _context = context;
        }

        public List<TopEntrantModel> Get()
        {
           return _context.Entrants.Select(t => new TopEntrantModel
                {
                Passport = t.Passport,
                Name = Concat(t.FirstName, " ",t.Name, " ",t.LastName),
                Points = t.Results.Select(x => x.Points).Sum()
                }
            )
            .OrderByDescending(q => q.Points)
            .ToList();
        }
    }
}