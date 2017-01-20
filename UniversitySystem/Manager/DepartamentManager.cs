using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem.Core.Exceptions;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class DepartamentManager : BaseManager<Departament> 
    {
        public DepartamentManager(RepositoryContext context) : base (context)
        {           
        }

        public List<DepartamentModel> Get()
        {
            return _context.Departaments
                .Select(x => new DepartamentModel
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();
        }        

        public DepartamentModel GetById(int id)
        {
            return _context.Departaments.Select(t => new DepartamentModel
            {
                Id = t.Id,
                Title = t.Title
            }).Single(x => x.Id == id);
        }

        public void Change(DepartamentModel model)
        {
            var departament = _context.Departaments.Single(x => x.Id == model.Id);

            departament.Title = model.Title;

            _context.SaveChanges();
        }

        public void Create(DepartamentModel model)
        {
            var departament = new Departament
            {
                Title = model.Title
            };

            _context.Departaments.Add(departament);
            _context.SaveChanges();
        }
    }
}