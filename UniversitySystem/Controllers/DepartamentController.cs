using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class DepartamentController : Controller
    {
        public DepartamentManager Manager
        {
            get
            {
                return new DepartamentManager(HttpContext.GetContextPerRequest());
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
            return View(new DepartamentModel());
        }

        [HttpPost]
        public ActionResult Create(DepartamentModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Create(model);
                return RedirectToAction("Index", "Departament");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {            
                Manager.Delete(id);
                return RedirectToAction("Index", "Departament");            
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            return View("Change", Manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(DepartamentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Manager.Change(model);
                    return RedirectToAction("Index", "Departament");
                }
                return View(model);
            }
            catch
            {
                return RedirectToAction("ServerView", "Error");
            }
        }
    }
}