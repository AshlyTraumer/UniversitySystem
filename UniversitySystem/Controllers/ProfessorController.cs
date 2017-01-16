using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using UniversitySystem.DAO;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class ProfessorController : Controller
    {
        public ActionResult Index()
        {
            return View(new ProfessorDAO().Get());
        }

        [HttpGet]        
        public ActionResult Create()
        {            
                return View(new ProfessorDAO().GetEmptyModel());          
        }

        [HttpPost]        
        public ActionResult Create(ProfessorModel model)
        {
            new ProfessorDAO().Create(model);
            return RedirectToAction("Index", "Professor");
        }

        [HttpGet]        
        public ActionResult Delete(int id)
        {
            new ProfessorDAO().Delete(id);
            return RedirectToAction("Index", "Professor");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            ProfessorModel professor = new ProfessorDAO().GetById(id);
            if (professor != null)
                return View("Change", professor);
            else
                return RedirectToAction("Index", "Professor");
        }

        [HttpPost]
        public ActionResult Change(ProfessorModel model)
        {
            new ProfessorDAO().Change(model);
            return RedirectToAction("Index", "Professor");
        }
    }
}