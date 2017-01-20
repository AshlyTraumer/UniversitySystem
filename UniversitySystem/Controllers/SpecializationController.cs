﻿using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class SpecializationController : Controller
    {
        public SpecializationManager Manager
        {
            get
            {
                return new SpecializationManager(HttpContext.GetContextPerRequest());
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
            return View(new SpecializationModel());
        }

        [HttpPost]
        public ActionResult Create(SpecializationModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Create(model);
                return RedirectToAction("Index", "Specialization");
            }
            ViewBag.List = Manager.GetList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Manager.Delete(id);
            return RedirectToAction("Index", "Specialization");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {            
            ViewBag.List = Manager.GetList();
            return View("Change", Manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(SpecializationModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Change(model);                
                return RedirectToAction("Index", "Specialization");
            }
            ViewBag.List = Manager.GetList();
            return View(model);
        }
    }
}