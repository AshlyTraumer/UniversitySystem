using ClassLibrary;
using ClassLibrary.Authorization;
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
    public class DepartamentController : Controller
    {
        private readonly RepositoryContext _context;

        public DepartamentController()
        {
            _context = HttpContext.GetContextPerRequest();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new DepartamentManager(_context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DepartamentModel());
        }

        [HttpPost]
        public ActionResult Create(DepartamentModel model)
        {
            new DepartamentManager(_context).Create(model);
            return RedirectToAction("Index", "Departament");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new DepartamentManager(_context).Delete(id);
            return RedirectToAction("Index", "Departament");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            DepartamentModel departament = new DepartamentManager(_context).GetById(id);
            return View("Change", departament);
        }

        [HttpPost]
        public ActionResult Change(DepartamentModel model)
        {
            new DepartamentManager(_context).Change(model);
            return RedirectToAction("Index", "Departament");
        }
    }
}