using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class CommitteeController : Controller
    {
        private ResultManager _manager => new ResultManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Index()
        {
            return View(_manager.Get());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index", "Committee");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            ViewBag.List = _manager.GetList();
            return View("Change", _manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(ResultModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _manager.Change(model);
                    return RedirectToAction("Index", "Committee");
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