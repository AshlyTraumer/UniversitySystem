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
        private RepositoryContext context;
        public DepartamentManager(RepositoryContext context)
        {
            this.context = context;
        }

        public IEnumerable<Departament> Get()
        {
            return context.Departaments.Select(x => x);
        }

        public void Delete(int id)
        {
            Departament departament = context.Departaments.Single(x => x.Id == id);
            context.Departaments.Remove(departament);
            context.SaveChanges();
        }

        public DepartamentModel GetById(int id)
        {
            Departament departament = context.Departaments.Single(x => x.Id == id);
            DepartamentModel model = new DepartamentModel()
            {
                Id = id,
                Title = departament.Title
            };

            return model;
        }

        public void Change(DepartamentModel instance)
        {
            Departament departament = context.Departaments.Single(x => x.Id == instance.Id);
            departament.Title = instance.Title;
            context.SaveChanges();
        }

        public void Create(DepartamentModel departament)
        {
            Departament newDepartament = new Departament()
            {
                Title = departament.Title
            };

            context.Departaments.Add(newDepartament);
            context.SaveChanges();
        }

    }
}