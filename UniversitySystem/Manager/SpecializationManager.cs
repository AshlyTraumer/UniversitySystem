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
        private RepositoryContext _context;
        public SpecializationManager(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<SpecializationViewModel> Get()
        {
            IEnumerable<SpecializationViewModel> uModel = _context.Specializations
                .Join(
                _context.Departaments,
                x => x.DepartamentId,
                y => y.Id,
                (x, y) => new SpecializationViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    FreeCount = x.FreeCount,
                    PayCount = x.PayCount,
                    Departament = y.Title                    
                }).ToList(); ;
            return uModel;
        }

        public void Delete(int id)
        {
            Specialization specialization = _context.Specializations.Single(x => x.Id == id);
            _context.Specializations.Remove(specialization);
            _context.SaveChanges();
        }

        public SpecializationModel GetById(int id)
        {
            Specialization specialization = _context.Specializations.Single(x => x.Id == id);

            SpecializationModel model = new SpecializationModel()
            {
                Id = id,                
                Title = specialization.Title,
                FreeCount = specialization.FreeCount,
                PayCount = specialization.PayCount,
                DepartamentId = specialization.DepartamentId,
                Departaments = _context.Departaments
            };
            return model;
        }

        public SpecializationModel GetEmptyModel()
        {
            SpecializationModel model = new SpecializationModel()
            {
                Departaments = _context.Departaments
            };
            return model;
        }

        public void Change(SpecializationModel instance)
        {
            Departament departament = _context.Departaments.Single(x => x.Id == instance.DepartamentId);
            Specialization specialization = _context.Specializations.Single(x => x.Id == instance.Id);
            specialization.Title = instance.Title;
            specialization.FreeCount = instance.FreeCount;
            specialization.PayCount = instance.PayCount;
            specialization.Departament = departament;
            _context.SaveChanges();
        }

        public void Create(SpecializationModel model)
        {
            Departament departament = _context.Departaments.Single(x => x.Id == model.DepartamentId);
            Specialization specialization = new Specialization()
            {
                Title = model.Title,
                PayCount = model.PayCount,
                FreeCount = model.FreeCount,
                Departament = departament
            };

            _context.Specializations.Add(specialization);
            _context.SaveChanges();
        }
    }
}