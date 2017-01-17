using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class DepartamentManager //: DAO<Departament>
    {
        private RepositoryContext _context;
        public DepartamentManager(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<DepartamentModel> Get()
        {
            IEnumerable<DepartamentModel> uModel = _context.Departaments.Select(x => new DepartamentModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
            return uModel;
        }

        public void Delete(int id)
        {
            Departament departament = _context.Departaments.Single(x => x.Id == id);
            _context.Departaments.Remove(departament);
            _context.SaveChanges();
        }

        public DepartamentModel GetById(int id)
        {
            Departament departament = _context.Departaments.Single(x => x.Id == id);
            DepartamentModel model = new DepartamentModel()
            {
                Id = id,
                Title = departament.Title
            };

            return model;
        }

        public void Change(DepartamentModel instance)
        {
            Departament departament = _context.Departaments.Single(x => x.Id == instance.Id);
            departament.Title = instance.Title;
            _context.SaveChanges();
        }

        public void Create(DepartamentModel departament)
        {
            Departament newDepartament = new Departament()
            {
                Title = departament.Title
            };

            _context.Departaments.Add(newDepartament);
            _context.SaveChanges();
        }

    }
}