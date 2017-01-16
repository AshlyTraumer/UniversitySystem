using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.DAO
{
    public class ProfessorDAO
    {
        public RepositoryContext context = new RepositoryContext();
        public IEnumerable<Professor> Get()
        {
            return context.Professors.Include("Departament");
        }

        public void Delete(int id)
        {
            Professor professor = context.Professors.FirstOrDefault(x => x.Id == id);
            if (professor != null)
            {
                context.Professors.Remove(professor);
                context.SaveChanges();
            }
        }

        public ProfessorModel GetById(int id)
        {
            Professor professor = context.Professors.FirstOrDefault(x => x.Id == id);
            ProfessorModel model = new ProfessorModel()
            {
                Id = id,
                Name = professor.Name,
                DepartamentId = professor.DepartamentId
            };
            return model;
        }

        public void Change(ProfessorModel instance)
        {
            /*Departament departament = context.Departaments.FirstOrDefault(x => x.Id == instance.Departament.Id);
            Professor professor = new Professor()
            {
                Name = instance.Name,
                Departament = departament
            };
            context.SaveChanges();*/
        }

        public void Create(ProfessorModel model)
        {
            Professor professor = new Professor()
            {
                Name = model.Name,
                Departament = context.Departaments.First(x => x.Id == model.DepartamentId)
            };
            context.Professors.Add(professor);
            context.SaveChanges();            
        }
    }
}