using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class EntrantController : Controller
    {
        private EntrantManager _manager => new EntrantManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Index()
        {
            return View(_manager.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.List = _manager.GetList();
            return View(new EntrantModel());
        }

        [HttpPost]
        public ActionResult Create(EntrantModel model)
        {
            if (ModelState.IsValid)
            {
                _manager.Create(model);
                return RedirectToAction("Index", "Entrant");
            }
            ViewBag.List = _manager.GetList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index", "Entrant");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            ViewBag.List = _manager.GetList();
            return View("Change", _manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(EntrantModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _manager.Change(model);
                    return RedirectToAction("Index", "Entrant");
                }
                ViewBag.List = _manager.GetList();
                return View(model);
            }
            catch
            {
                return RedirectToAction("Http500", "Error");
            }
        }

        
    }
}
