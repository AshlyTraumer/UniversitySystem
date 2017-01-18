using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class SpecializationController : Controller
    {
        RepositoryContext _context;
        public SpecializationController()
        {
            _context = new RepositoryContext();
            _context.Database.Log = LogMethod;
        }

        public void LogMethod(string str)
        {
            FileStream fs = new FileStream("e:\\UniversitySystem\\Specialization.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(str);
            sw.Close();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new SpecializationManager(_context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SpecializationManager(_context).GetEmptyModel());
        }

        [HttpPost]
        public ActionResult Create(SpecializationModel model)
        {
            new SpecializationManager(_context).Create(model);
            return RedirectToAction("Index", "Specialization");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new SpecializationManager(_context).Delete(id);
            return RedirectToAction("Index", "Specialization");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            SpecializationModel specialization = new SpecializationManager(_context).GetById(id);
            return View("Change", specialization);
        }

        [HttpPost]
        public ActionResult Change(SpecializationModel model)
        {
            new SpecializationManager(_context).Change(model);
            return RedirectToAction("Index", "Specialization");
        }
    }
}