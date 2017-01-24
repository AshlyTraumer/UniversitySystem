using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class EntrantManager : BaseManager<Entrant, EntrantModel>
    {
        public EntrantManager(RepositoryContext context) : base (context)
        {
        }

        public List<EntrantViewModel> Get()
        {
            return Context.Entrants
                .Select(x => new EntrantViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    DateOfBirth = x.DateOfBirth,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Passport = x.Passport
                }).ToList();
        }

        public EntrantModel GetById(int id)
        {
            return Context.Entrants.Select(x => new EntrantModel
            {
                Id = x.Id,
                Name = x.Name,
                DateOfBirth = x.DateOfBirth,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Passport = x.Passport
            })
            .Single(x => x.Id == id);
        }

        public List<DropDownListItem> GetList()
        {
            return Context.Specializations
                .Select(x => new DropDownListItem
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();
        }

        public void Create(EntrantModel model)
        {
            var subjects = Context.SubjectsSpecialization
                .Where(x => x.SpecializationId == model.SpecializationId)
                .ToList();

            var list = new List<Result>();
            foreach (var s in subjects)
            {
                var n = new Result
                {
                    SubjectId = s.SubjectId
                };
                list.Add(n);
            }

            var entrant = new Entrant
            {
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Passport = model.Passport,
                Results = list
            };

            Context.Entrants.Add(entrant);
            Context.SaveChanges();
        }

        protected override void Update(Entrant entity, EntrantModel model)
        {
            entity.Name = model.Name;
            entity.DateOfBirth = model.DateOfBirth;            
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Passport = model.Passport;
        }
    }
}