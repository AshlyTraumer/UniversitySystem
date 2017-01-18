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
using UniversitySystem.Core;

namespace UniversitySystem.Controllers
{
    public class ProfessorController : Controller
    {
        private RepositoryContext _context;
        public RepositoryContext Context
        {
            get
            {
                _context = HttpContext.GetContextPerRequest("Start.txt");
                return _context;
            }
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
            return View(new ProfessorManager(Context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProfessorManager(Context).GetEmptyModel());
        }

        [HttpPost]
        public ActionResult Create(ProfessorModel model)
        {
            new ProfessorManager(Context).Create(model);
            return RedirectToAction("Index", "Professor");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new ProfessorManager(Context).Delete(id);
            return RedirectToAction("Index", "Professor");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            ProfessorModel professor = new ProfessorManager(Context).GetById(id);
            return View("Change", professor);
        }

        [HttpPost]
        public ActionResult Change(ProfessorModel model)
        {
            new ProfessorManager(Context).Change(model);
            return RedirectToAction("Index", "Professor");
        }
    }
}