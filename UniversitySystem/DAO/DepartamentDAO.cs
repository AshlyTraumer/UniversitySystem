using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.DAO
{
    public class DepartamentDAO //: DAO<Departament>
    {
        public RepositoryContext context = new RepositoryContext();
        public IEnumerable<Departament> Get()
        {
            return context.Departaments;
        }

        public void Delete(int id)
        {
            Departament departament = context.Departaments.FirstOrDefault(x => x.Id == id);
            if (departament != null)
            {                
                context.Departaments.Remove(departament);
                context.SaveChanges();
            }
        }

        public DepartamentModel GetById(int id)
        {
            DepartamentModel model = new DepartamentModel()
            {
                Id = id,
                Title = context.Departaments.FirstOrDefault(x => x.Id == id).Title
            };
            return model;
        }

        public void Change(DepartamentModel instance)
        {
            Departament departament = context.Departaments.FirstOrDefault(x => x.Id == instance.Id);
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