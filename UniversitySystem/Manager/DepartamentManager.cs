using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem.Core.Exceptions;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class DepartamentManager 
    {
        private readonly RepositoryContext _context;

        public DepartamentManager(RepositoryContext context)
        {
            _context = context;
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

        public void Delete(int id)
        {
            var departament = _context.Departaments.SingleOrDefault(x => x.Id == id);

            if (departament == null)
                throw new UniversalException("Departament not found id = " + id);

            _context.Departaments.Remove(departament);
            _context.SaveChanges();
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