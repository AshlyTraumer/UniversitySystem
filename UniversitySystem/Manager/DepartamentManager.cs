﻿using ClassLibrary;
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
                }).ToList();
        }

        public void Delete(int id)
        {
            var departament = _context.Departaments.Single(x => x.Id == id);

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

        public void Change(DepartamentModel instance)
        {
            var departament = _context.Departaments.Single(x => x.Id == instance.Id);

            departament.Title = instance.Title;

            _context.SaveChanges();
        }

        public void Create(DepartamentModel departament)
        {
            var newDepartament = new Departament
            {
                Title = departament.Title
            };

            _context.Departaments.Add(newDepartament);
            _context.SaveChanges();
        }
    }
}