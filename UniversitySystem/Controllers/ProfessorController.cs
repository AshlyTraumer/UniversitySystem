using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using UniversitySystem.Models;
using UniversitySystem.Manager;
using System.IO;

namespace UniversitySystem.Controllers
{
    public class ProfessorController : Controller
    {
        RepositoryContext _context;
        public ProfessorController()
        {
            _context = new RepositoryContext();
            _context.Database.Log = LogMethod;
        }

        public void LogMethod(string str)
        {
            FileStream fs = new FileStream("e:\\UniversitySystem\\Professor.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(str);
            sw.Close();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new ProfessorManager(_context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProfessorManager(_context).GetEmptyModel());
        }

        [HttpPost]
        public ActionResult Create(ProfessorModel model)
        {
            new ProfessorManager(_context).Create(model);
            return RedirectToAction("Index", "Professor");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new ProfessorManager(_context).Delete(id);
            return RedirectToAction("Index", "Professor");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            ProfessorModel professor = new ProfessorManager(_context).GetById(id);
            return View("Change", professor);
        }

        [HttpPost]
        public ActionResult Change(ProfessorModel model)
        {
            new ProfessorManager(_context).Change(model);
            return RedirectToAction("Index", "Professor");
        }
    }
}