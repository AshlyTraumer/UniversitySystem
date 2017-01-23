using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem.Models;
using System;

namespace UniversitySystem.Manager
{
    public class SpecializationManager : BaseManager <Specialization, SpecializationModel>
    {       
        public SpecializationManager(RepositoryContext context) :base (context)
        {            
        }

        public List<SpecializationViewModel> Get()
        {
            return Context.Specializations
                .Select(x => new SpecializationViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    FreeCount = x.FreeCount,
                    PayCount = x.PayCount,
                    Departament = x.Departament.Title
                }).ToList();
        }        

        public SpecializationModel GetById(int id)
        {
            var model = Context.Specializations
                .Select(x => new SpecializationModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    PayCount = x.PayCount,
                    FreeCount = x.FreeCount,
                }).Single(x => x.Id == id);            

            return model;
        }

        public List<DropDownListItem> GetList()
        {
            return  Context.Departaments
                .Select(x => new DropDownListItem
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();            
        }

        public void Create(SpecializationModel model)
        {
            var specialization = new Specialization
            {
                Title = model.Title,
                PayCount = model.PayCount,
                FreeCount = model.FreeCount,
                DepartamentId = model.DepartamentId
            };

            Context.Specializations.Add(specialization);
            Context.SaveChanges();
        }

        protected override void Update(Specialization entity, SpecializationModel model)
        {
            entity.Title = model.Title;
            entity.FreeCount = model.FreeCount;
            entity.PayCount = model.PayCount;
        }

        public List<SpecializationViewModel> GetListById(int id)
        {
            return Context.Specializations
                .Where(x => x.DepartamentId == id)
                .Select(x => new SpecializationViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    FreeCount = x.FreeCount,
                    PayCount = x.PayCount,
                    Departament = x.Departament.Title
                }).ToList();
        }
    }
}