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
        private RepositoryContext _context;        
        public RepositoryContext Context
        {
            get
            {
                _context = HttpContext.GetContextPerRequest("Departament.txt");
                return _context;
            }
        }

        public DepartamentController()
        {           
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new DepartamentManager(Context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DepartamentModel());
        }

        [HttpPost]
        public ActionResult Create(DepartamentModel model)
        {
            new DepartamentManager(Context).Create(model);
            return RedirectToAction("Index", "Departament");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new DepartamentManager(Context).Delete(id);
            return RedirectToAction("Index", "Departament");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            DepartamentModel departament = new DepartamentManager(Context).GetById(id);
            return View("Change", departament);
        }

        [HttpPost]
        public ActionResult Change(DepartamentModel model)
        {
            new DepartamentManager(Context).Change(model);
            return RedirectToAction("Index", "Departament");
        }
    }
}