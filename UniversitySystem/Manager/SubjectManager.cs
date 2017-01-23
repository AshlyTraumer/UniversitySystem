using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class SubjectManager : BaseManager<Subject, SubjectModel>
    {       
        public SubjectManager(RepositoryContext context) : base (context)
        {
            Context = context;
        }

        public List<SubjectModel> Get()
        {
            return Context.Subjects
                .Select(x => new SubjectModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Form = x.Form
                }).ToList();
        }        

        public SubjectModel GetById(int id)
        {
            var subject = Context.Subjects.Single(x => x.Id == id);

            return new SubjectModel
            {
                Id = id,
                Title = subject.Title,
                Form = subject.Form
            };            
        }

        public void Create(SubjectModel model)
        {
            var subject = new Subject
            {
                Title = model.Title,
                Form = model.Form
            };

            Context.Subjects.Add(subject);
            Context.SaveChanges();
        }

        protected override void Update(Subject entity, SubjectModel model)
        {
            entity.Title = model.Title;
            entity.Form = model.Form;
        }
    }
}