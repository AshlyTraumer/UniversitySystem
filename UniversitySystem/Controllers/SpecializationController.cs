using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class SpecializationController : Controller
    {
        private RepositoryContext _context;
        public RepositoryContext Context
        {
            get
            {
                _context = HttpContext.GetContextPerRequest("Specialization.txt");
                return _context;
            }
        }
       
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SpecializationManager(Context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SpecializationManager(Context).GetEmptyModel());
        }

        [HttpPost]
        public ActionResult Create(SpecializationModel model)
        {
            new SpecializationManager(Context).Create(model);
            return RedirectToAction("Index", "Specialization");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new SpecializationManager(Context).Delete(id);
            return RedirectToAction("Index", "Specialization");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            SpecializationModel specialization = new SpecializationManager(Context).GetById(id);
            return View("Change", specialization);
        }

        [HttpPost]
        public ActionResult Change(SpecializationModel model)
        {
            new SpecializationManager(Context).Change(model);
            return RedirectToAction("Index", "Specialization");
        }
    }
}