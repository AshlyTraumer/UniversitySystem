using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class SpecializationManager
    {
        private readonly RepositoryContext _context;
        public SpecializationManager(RepositoryContext context)
        {
            _context = context;
        }

        public List<SpecializationViewModel> Get()
        {
            return _context.Specializations
                .Select(x => new SpecializationViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    FreeCount = x.FreeCount,
                    PayCount = x.PayCount,
                    Departament = x.Departament.Title
                })
                .ToList();
        }

        public void Delete(int id)
        {
            var specialization = _context.Specializations.Single(x => x.Id == id);
            _context.Specializations.Remove(specialization);
            _context.SaveChanges();
        }

        public SpecializationModel GetById(int id)
        {
            var model = _context.Specializations
                .Select(x => new SpecializationModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    PayCount = x.PayCount,
                    FreeCount = x.FreeCount,
                })
                .Single(x => x.Id == id);            

            return model;
        }

        public List<DropDownList> GetList()
        {
            return  _context.Departaments
                .Select(x => new DropDownList
                {
                    Id = x.Id,
                    Title = x.Title
                })
                .ToList();            
        }

        public void Change(SpecializationModel model)
        {
            var specialization = _context.Specializations.Single(x => x.Id == model.Id);
            specialization.Title = model.Title;
            specialization.FreeCount = model.FreeCount;
            specialization.PayCount = model.PayCount;
            _context.SaveChanges();
        }

        public void Create(SpecializationModel model)
        {
            var departament = _context.Departaments.Single(x => x.Id == model.DepartamentId);
            Specialization specialization = new Specialization()
            {
                Title = model.Title,
                PayCount = model.PayCount,
                FreeCount = model.FreeCount,
                DepartamentId = model.DepartamentId
            };

            _context.Specializations.Add(specialization);
            _context.SaveChanges();
        }
    }
}