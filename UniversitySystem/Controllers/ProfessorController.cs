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

namespace UniversitySystem.Controllers
{
    public class ProfessorController : Controller
    {
        private RepositoryContext context;
        public ProfessorController()
        {
            context = new RepositoryContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new ProfessorManager(context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProfessorManager(context).GetEmptyModel());
        }

        [HttpPost]
        public ActionResult Create(ProfessorModel model)
        {
            new ProfessorManager(context).Create(model);
            return RedirectToAction("Index", "Professor");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new ProfessorManager(context).Delete(id);
            return RedirectToAction("Index", "Professor");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            ProfessorModel professor = new ProfessorManager(context).GetById(id);
            return View("Change", professor);
        }

        [HttpPost]
        public ActionResult Change(ProfessorModel model)
        {
            new ProfessorManager(context).Change(model);
            return RedirectToAction("Index", "Professor");
        }
    }
}