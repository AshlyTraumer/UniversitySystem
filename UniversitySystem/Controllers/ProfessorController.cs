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
using UniversitySystem.Core;

namespace UniversitySystem.Controllers
{
    public class ProfessorController : Controller
    {
        public ProfessorManager Manager
        {
            get
            {
                return new ProfessorManager(HttpContext.GetContextPerRequest());
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
            ViewBag.List = Manager.GetList();
            return View(new ProfessorModel());
        }

        [HttpPost]
        public ActionResult Create(ProfessorModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Create(model);
                return RedirectToAction("Index", "Professor");
            }
            ViewBag.List = Manager.GetList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {            
                Manager.Delete(id);
                return RedirectToAction("Index", "Professor");            
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            ViewBag.List = Manager.GetList();
            return View("Change", Manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(ProfessorModel model)
        {
            try { 
            if (ModelState.IsValid)
            {
                Manager.Change(model);
                return RedirectToAction("Index", "Professor");
            }
            ViewBag.List = Manager.GetList();
            return View(model);
            }
            catch
            {
                return RedirectToAction("ServerView", "Error");
            }
        }
    }
}