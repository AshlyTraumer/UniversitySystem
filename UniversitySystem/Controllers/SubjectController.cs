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
    public class SubjectController : Controller
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
            return View(new SubjectManager(Context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SubjectModel());
        }

        [HttpPost]
        public ActionResult Create(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                new SubjectManager(Context).Create(model);
                return RedirectToAction("Index", "Subject");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new SubjectManager(Context).Delete(id);
            return RedirectToAction("Index", "Subject");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            SubjectModel subject = new SubjectManager(Context).GetById(id);
            return View("Change", subject);
        }

        [HttpPost]
        public ActionResult Change(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                new SubjectManager(Context).Change(model);
                return RedirectToAction("Index", "Subject");
            }
            return View(model);
        }
    }
}