using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.DAO;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class DepartamentController : Controller
    {
        // GET: Departament     
        public ActionResult Index()
        {
            return View(new DepartamentDAO().Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DepartamentModel());
        }

        [HttpPost]
        public ActionResult Create(DepartamentModel model)
        {
            new DepartamentDAO().Create(model);
            return RedirectToAction("Index", "Departament");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new DepartamentDAO().Delete(id);
            return RedirectToAction("Index", "Departament");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            DepartamentModel departament = new DepartamentDAO().GetById(id);
            if (departament != null)
                return View("Change", departament);
            else
                return RedirectToAction("Index", "Departament");
        }

        [HttpPost]
        public ActionResult Change(DepartamentModel model)
        {
            new DepartamentDAO().Change(model);
            return RedirectToAction("Index", "Departament");
        }
    }
}