using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class ResultsController : Controller
    {
   /*     private ResultManager _manager => new ResultManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Create(int id)
        {
            return View(_manager.GetSpecializationListById(id));
        }

        [HttpPost]
        public ActionResult Create(ResultModel model)
        {
            if (ModelState.IsValid)
            {
                _manager.Create(model);
                return RedirectToAction("Create", "Results");
            }
            ViewBag.List = _manager.GetList();
            return View(model);
        }*/
    }
}