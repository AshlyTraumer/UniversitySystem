using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class DepartamentManager : BaseManager<Departament, DepartamentModel> 
    {
        public DepartamentManager(RepositoryContext context) : base (context)
        {           
        }

        public List<DepartamentModel> Get()
        {
            return Context.Departaments
                .Select(x => new DepartamentModel
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();
        }        

        public DepartamentModel GetById(int id)
        {
            return Context.Departaments.Select(t => new DepartamentModel
            {
                Id = t.Id,
                Title = t.Title
            }).Single(x => x.Id == id);
        }

        public void Create(DepartamentModel model)
        {
            var departament = new Departament
            {
                Title = model.Title
            };

            Context.Departaments.Add(departament);
            Context.SaveChanges();
        }

        protected override void Update(Departament entity,DepartamentModel model)
        {
            entity.Title = model.Title;
        }
    }
}