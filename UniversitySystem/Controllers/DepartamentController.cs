using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class DepartamentController : Controller
    {
        private RepositoryContext context;
        public DepartamentController()
        {
            context = new RepositoryContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new DepartamentManager(context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DepartamentModel());
        }

        [HttpPost]
        public ActionResult Create(DepartamentModel model)
        {
            new DepartamentManager(context).Create(model);
            return RedirectToAction("Index", "Departament");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new DepartamentManager(context).Delete(id);
            return RedirectToAction("Index", "Departament");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            DepartamentModel departament = new DepartamentManager(context).GetById(id);
            return View("Change", departament);
        }

        [HttpPost]
        public ActionResult Change(DepartamentModel model)
        {
            new DepartamentManager(context).Change(model);
            return RedirectToAction("Index", "Departament");
        }
    }
}