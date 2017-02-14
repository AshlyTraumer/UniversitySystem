using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class DepartamentController : Controller
    {
        private DepartamentManager _manager => new DepartamentManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Index()
        {
           
            return View(_manager.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DepartamentModel());
        }

        [HttpPost]
        public ActionResult Create(DepartamentModel model)
        {
            if (!ModelState.IsValid) return View(model);
            _manager.Create(model);
            return RedirectToAction("Index", "Departament");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index", "Departament");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            return View("Change", _manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(DepartamentModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                _manager.Change(model);
                return RedirectToAction("Index", "Departament");
            }
            catch
            {
                return RedirectToAction("Http500", "Error");
            }
        }
    }
}