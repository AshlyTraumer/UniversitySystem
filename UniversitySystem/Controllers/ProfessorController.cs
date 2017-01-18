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
                _context = HttpContext.GetContextPerRequest();
                return _context;
            }
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ProfessorManager(Context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.List = new ProfessorManager(Context).GetList();
            return View(new ProfessorModel());
        }

        [HttpPost]
        public ActionResult Create(ProfessorModel model)
        {
            if (ModelState.IsValid)
            {
                new ProfessorManager(Context).Create(model);
                return RedirectToAction("Index", "Professor");
            }
            ViewBag.List = new ProfessorManager(Context).GetList();
            return View(model);
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
            var manager = new ProfessorManager(Context);
            ProfessorModel professor = manager.GetById(id);
            ViewBag.List = manager.GetList();
            return View("Change", professor);
        }

        [HttpPost]
        public ActionResult Change(ProfessorModel model)
        {
            if (ModelState.IsValid)
            {
                new ProfessorManager(Context).Change(model);
                return RedirectToAction("Index", "Professor");
            }
            ViewBag.List = new ProfessorManager(Context).GetList();
            return View(model);
        }
    }
}