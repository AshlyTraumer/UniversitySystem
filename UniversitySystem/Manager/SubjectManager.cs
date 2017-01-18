using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class SubjectManager
    {
        private RepositoryContext _context;
        public SubjectManager(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<SubjectModel> Get()
        {
            IEnumerable<SubjectModel> uModel = _context.Subjects.Select(x => new SubjectModel
            {
                Id = x.Id,
                Title = x.Title,
                Form=x.Form
            }).ToList();
            return uModel;
        }

        public void Delete(int id)
        {
            Subject subject = _context.Subjects.Single(x => x.Id == id);
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
        }

        public SubjectModel GetById(int id)
        {
            Subject subject = _context.Subjects.Single(x => x.Id == id);
            SubjectModel model = new SubjectModel()
            {
                Id = id,
                Title = subject.Title,
                Form = subject.Form
            };

            return model;
        }

        public void Change(SubjectModel instance)
        {
            Subject subject = _context.Subjects.Single(x => x.Id == instance.Id);
            subject.Title = instance.Title;
            subject.Form = instance.Form;
            _context.SaveChanges();
        }

        public void Create(SubjectModel instance)
        {
            Subject subject= new Subject()
            {
                Title = instance.Title,
                Form = instance.Form
            };

            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }
    }
}