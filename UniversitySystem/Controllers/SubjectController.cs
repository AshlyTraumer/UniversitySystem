﻿using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class SubjectController : Controller
    {
        public SubjectManager Manager
        {
            get
            {
                return new SubjectManager(HttpContext.GetContextPerRequest());
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(Manager.Get());
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
                Manager.Create(model);
                return RedirectToAction("Index", "Subject");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Manager.Delete(id);
            return RedirectToAction("Index", "Subject");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {           
            return View("Change", Manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Change(model);
                return RedirectToAction("Index", "Subject");
            }
            return View(model);
        }
    }
}