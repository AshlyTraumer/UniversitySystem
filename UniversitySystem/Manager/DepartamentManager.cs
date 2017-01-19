using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                })
                .ToList();
        }

        public void Delete(int id)
        {
            var departament = _context.Departaments.SingleOrDefault(x => x.Id == id);
            if (departament == null)
                throw new UniversalException("Departament");
            _context.Departaments.Remove(departament);
            _context.SaveChanges();
        }

        public DepartamentModel GetById(int id)
        {
            var departament = _context.Departaments.Single(x => x.Id == id);

            var model = new DepartamentModel
            {
                Id = id,
                Title = departament.Title
            };

            return model;
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