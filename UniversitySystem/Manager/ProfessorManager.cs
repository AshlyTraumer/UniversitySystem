using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class ProfessorManager : BaseManager<Professor, ProfessorModel>
    {
        public ProfessorManager(RepositoryContext context) : base (context)
        {           
        }

        public List<ProfessorViewModel> Get()
        {
            return Context.Professors
                .Select(t => new ProfessorViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    DepartamentTitle = t.Departament.Title
                }).ToList();
        }        

        public ProfessorModel GetById(int id)
        {
            var professor = Context.Professors.Single(x => x.Id == id);
            
            var model = new ProfessorModel
            {
                Id = id,
                Name = professor.Name,               
            };

            return model;
        }


        public List<DropDownListItem> GetList()
        {
            return Context.Departaments
                .Select(x => new DropDownListItem
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();            
        }

        public void Create(ProfessorModel model)
        {
            var professor = new Professor
            {
                Name = model.Name,
                DepartamentId = model.DepartamentId
            };

            Context.Professors.Add(professor);
            Context.SaveChanges();
        }
       

        protected override void Update(Professor entity, ProfessorModel model)
        {
            entity.Name = model.Name;
            entity.DepartamentId = model.DepartamentId;
        }

        public List<ProfessorViewModel> GetListById(int id)
        {
            return Context.Professors
                .Where(x => x.DepartamentId == id)
                .Select(t => new ProfessorViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    DepartamentTitle = t.Departament.Title
                })
                .ToList();
        }
    }
}