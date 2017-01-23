using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class SpecializationController : Controller
    {
        private SpecializationManager _manager => new SpecializationManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Index()
        {
            return View(_manager.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.List = _manager.GetList();
            return View(new SpecializationModel());
        }

        [HttpPost]
        public ActionResult Create(SpecializationModel model)
        {
            if (ModelState.IsValid)
            {
                _manager.Create(model);
                return RedirectToAction("Index", "Specialization");
            }
            ViewBag.List = _manager.GetList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try { 
            _manager.Delete(id);
            return RedirectToAction("Index", "Specialization");
            }
            catch
            {
                return RedirectToAction("Http500", "Error");
            }
        }

        [HttpGet]
        public ActionResult Change(int id)
        {            
            ViewBag.List = _manager.GetList();
            return View("Change", _manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(SpecializationModel model)
        {
            if (ModelState.IsValid)
            {
                _manager.Change(model);                
                return RedirectToAction("Index", "Specialization");
            }
            ViewBag.List = _manager.GetList();
            return View(model);            
        }

        public ActionResult Select(int id)
        {
            return View(_manager.GetListById(id));
        }
    }
}