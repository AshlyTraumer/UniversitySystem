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
        private RepositoryContext _context;
        public ProfessorManager(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<ProfessorViewModel> Get()
        {            
            IEnumerable<ProfessorViewModel> uModel = _context.Professors
                .Join(
                _context.Departaments,
                x => x.DepartamentId,
                y => y.Id,
                (x, y) => new ProfessorViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    DepartamentTitle = y.Title
                }).ToList(); ;
            return uModel;
        }

        public void Delete(int id)
        {
            Professor professor = _context.Professors.Single(x => x.Id == id);
            _context.Professors.Remove(professor);
            _context.SaveChanges();
        }

        public ProfessorModel GetById(int id)
        {
            Professor professor = _context.Professors.Single(x => x.Id == id);

            ProfessorModel model = new ProfessorModel()
            {
                Id = id,
                Name = professor.Name,
                DepartamentId = professor.DepartamentId,
                Departaments = _context.Departaments
            };
            return model;
        }

        public ProfessorModel GetEmptyModel()
        {
            ProfessorModel model = new ProfessorModel()
            {
                Departaments = _context.Departaments
            };
            return model;
        }

        public void Change(ProfessorModel instance)
        {
            Departament departament = _context.Departaments.Single(x => x.Id == instance.DepartamentId);
            Professor professor = _context.Professors.Single(x => x.Id == instance.Id);
            professor.Name = instance.Name;
            professor.Departament = departament;
            _context.SaveChanges();
        }

        public void Create(ProfessorModel model)
        {
            Departament departament = _context.Departaments.Single(x => x.Id == model.DepartamentId);
            Professor professor = new Professor()
            {
                Name = model.Name,
                Departament = departament
            };

            _context.Professors.Add(professor);
            _context.SaveChanges();
        }
    }
}