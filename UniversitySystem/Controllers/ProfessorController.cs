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
        private ProfessorManager _manager => new ProfessorManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Index()
        {
            return View(_manager.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.List = _manager.GetList();
            return View(new ProfessorModel());
        }

        [HttpPost]
        public ActionResult Create(ProfessorModel model)
        {
            if (ModelState.IsValid)
            {
               //_manager.Create(model);
                return RedirectToAction("Index", "Professor");
            }
           // ViewBag.List = _manager.GetList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {            
                _manager.Delete(id);
                return RedirectToAction("Index", "Professor");            
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            ViewBag.List = _manager.GetList();
            return View("Change", _manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(ProfessorModel model)
        {
            try { 
            if (ModelState.IsValid)
            {
                _manager.Change(model);
                return RedirectToAction("Index", "Professor");
            }
            ViewBag.List = _manager.GetList();
            return View(model);
            }
            catch
            {
                return RedirectToAction("Http500", "Error");
            }
        }

        public ActionResult Select(int id)
        {
            return View(_manager.GetListById(id));
        }
    }
}