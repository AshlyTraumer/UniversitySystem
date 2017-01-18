using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class ProfessorManager
    {
        private readonly RepositoryContext _context;
        public ProfessorManager(RepositoryContext context)
        {
            _context = context;
        }

        public List<ProfessorViewModel> Get()
        {
            return _context.Professors.Select(t => new ProfessorViewModel
            {
                Id = t.Id,
                Name = t.Name,
                DepartamentTitle = t.Departament.Title
            }).ToList();
        }

        public void Delete(int id)
        {
            var professor = _context.Professors.Single(x => x.Id == id);

            _context.Professors.Remove(professor);
            _context.SaveChanges();
        }

        //TODO 
        public ProfessorModel GetById(int id)
        {
            var professor = _context.Professors.Single(x => x.Id == id);

            var model = new ProfessorModel
            {
                Id = id,
                Name = professor.Name,
                DepartamentId = professor.DepartamentId,
                Departaments = _context.Departaments
            };

            return model;
        }

        //TODO
        public ProfessorModel GetEmptyModel()
        {
            var model = new ProfessorModel
            {
                Departaments = _context.Departaments
            };

            return model;
        }

        public void Change(ProfessorModel instance)
        {
            var professor = _context.Professors.Single(x => x.Id == instance.Id);

            professor.Name = instance.Name;
            professor.DepartamentId = instance.DepartamentId;

            _context.SaveChanges();
        }

        public void Create(ProfessorModel model)
        {
            var professor = new Professor
            {
                Name = model.Name,
                DepartamentId = model.DepartamentId
            };

            _context.Professors.Add(professor);
            _context.SaveChanges();
        }
    }
}