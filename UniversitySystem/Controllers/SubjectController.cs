using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class SubjectController : Controller
    {
        private SubjectManager _manager => new SubjectManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Index()
        {
            return View(_manager.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SubjectModel());
        }

        [HttpPost]
        public ActionResult Create(SubjectModel model)
        {
            if (!ModelState.IsValid) return View(model);
            _manager.Create(model);
            return RedirectToAction("Index", "Subject");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index", "Subject");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            return View("Change", _manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(SubjectModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _manager.Change(model);
                    return RedirectToAction("Index", "Subject");
                }
                return View(model);
            }
            catch
            {
                return RedirectToAction("Http500", "Error");
            }
        }
    }
}