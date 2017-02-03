using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using UniversitySystem.Models.ReportModel;

namespace UniversitySystem.Report
{
    public class SpecialityMinMaxQuery : IQueryParam<int, SpecialityMinMaxModel>
    {
        //ид, название, мин балл, макс балл
        private readonly RepositoryContext _context;

        public SpecialityMinMaxQuery(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<SpecialityMinMaxModel> GetAsync(int param)
        {
            var list = await _context.SubjectsSpecialization
                .Where(q => q.SpecializationId == param)
                .Select(q => new
                {
                    q.Specialization.Title,
                    MinPoint = q.Subject.Results.Select(w => w.Points).Min(),
                    MaxPoint = q.Subject.Results.Select(w => w.Points).Max()
                })
                .ToListAsync();


            return new SpecialityMinMaxModel
            {
                Title = list.Select(w => w.Title).First(),
                Id = param,
                MinPoint = list.Select(w => w.MinPoint).Min(),
                MaxPoint = list.Select(w => w.MaxPoint).Max()
            };

        }

        public SpecialityMinMaxModel Get(int param)
        {
            var list = _context.SubjectsSpecialization
               .Where(q => q.SpecializationId == param)
               .Select(q => new
               {
                   q.Specialization.Title,
                   MinPoint = q.Subject.Results.Select(w => w.Points).Min(),
                   MaxPoint = q.Subject.Results.Select(w => w.Points).Max()
               })
               .ToList();


            return new SpecialityMinMaxModel
            {
                Title = list.Select(w => w.Title).First(),
                Id = param,
                MinPoint = list.Select(w => w.MinPoint).Min(),
                MaxPoint = list.Select(w => w.MaxPoint).Max()
            };
        }
    }
}