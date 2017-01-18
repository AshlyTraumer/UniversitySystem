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
                _context = HttpContext.GetContextPerRequest();
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
            ViewBag.List = new SpecializationManager(Context).GetList();
            return View(new SpecializationModel());
        }

        [HttpPost]
        public ActionResult Create(SpecializationModel model)
        {
            if (ModelState.IsValid)
            {
                new SpecializationManager(Context).Create(model);
                return RedirectToAction("Index", "Specialization");
            }
            ViewBag.List = new SpecializationManager(Context).GetList();
            return View(model);
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
            var manager = new SpecializationManager(Context);
            var specialization = manager.GetById(id);
            ViewBag.List = manager.GetList();
            return View("Change", specialization);
        }

        [HttpPost]
        public ActionResult Change(SpecializationModel model)
        {
            if (ModelState.IsValid)
            {
                new SpecializationManager(Context).Change(model);                
                return RedirectToAction("Index", "Specialization");
            }
            ViewBag.List = new SpecializationManager(Context).GetList();
            return View(model);
        }
    }
}