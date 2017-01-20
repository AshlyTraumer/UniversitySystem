using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class SubjectManager : BaseManager<Subject>
    {       
        public SubjectManager(RepositoryContext context) : base (context)
        {
            _context = context;
        }

        public List<SubjectModel> Get()
        {
            return _context.Subjects
                .Select(x => new SubjectModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Form = x.Form
                }).ToList();
        }        

        public SubjectModel GetById(int id)
        {
            var subject = _context.Subjects.Single(x => x.Id == id);

            return new SubjectModel
            {
                Id = id,
                Title = subject.Title,
                Form = subject.Form
            };            
        }

        public void Change(SubjectModel model)
        {
            var subject = _context.Subjects.Single(x => x.Id == model.Id);

            subject.Title = model.Title;
            subject.Form = model.Form;

            _context.SaveChanges();
        }

        public void Create(SubjectModel model)
        {
            var subject = new Subject
            {
                Title = model.Title,
                Form = model.Form
            };

            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }
    }
}