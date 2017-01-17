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
        private RepositoryContext context;
        public ProfessorManager(RepositoryContext context)
        {
            this.context = context;
        }

        public IEnumerable<Professor> Get()
        {
            return context.Professors.Include("Departament").Select(x => x);
        }

        public void Delete(int id)
        {
            Professor professor = context.Professors.Single(x => x.Id == id);
            context.Professors.Remove(professor);
            context.SaveChanges();
        }

        public ProfessorModel GetById(int id)
        {
            Professor professor = context.Professors.FirstOrDefault(x => x.Id == id);

            ProfessorModel model = new ProfessorModel()
            {
                Id = id,
                Name = professor.Name,
                DepartamentId = professor.DepartamentId,
                Departaments = context.Departaments
            };
            return model;
        }

        public ProfessorModel GetEmptyModel()
        {
            ProfessorModel model = new ProfessorModel()
            {
                Departaments = context.Departaments
            };
            return model;
        }

        public void Change(ProfessorModel instance)
        {
            Departament departament = context.Departaments.Single(x => x.Id == instance.DepartamentId);
            Professor professor = context.Professors.Single(x => x.Id == instance.Id);
            professor.Name = instance.Name;
            professor.Departament = departament;
            context.SaveChanges();
        }

        public void Create(ProfessorModel model)
        {
            Departament departament = context.Departaments.First(x => x.Id == model.DepartamentId);
            Professor professor = new Professor()
            {
                Name = model.Name,
                Departament = departament
            };

            context.Professors.Add(professor);
            context.SaveChanges();
        }
    }
}