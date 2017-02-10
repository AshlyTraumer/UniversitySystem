using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class SecretaryController : Controller
    {
        private ScheduleManager _manager => new ScheduleManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Index()
        {
            return View(_manager.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            ViewBag.ProfessorList = _manager.GetProfessorList();
            ViewBag.SubjectList = _manager.GetSubjectList();
            return View(new ScheduleModel());
        }

        [HttpPost]
        public ActionResult Create(ScheduleModel model)
        {
            
            if (ModelState.IsValid)
            {
                _manager.Create(model);
                return RedirectToAction("Index", "Secretary");
            }
            ViewBag.ProfessorList = _manager.GetProfessorList();
            ViewBag.SubjectList = _manager.GetSubjectList();
            return View(model);

            
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index", "Secretary");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            ViewBag.ProfessorList = _manager.GetProfessorList();
            ViewBag.SubjectList = _manager.GetSubjectList();
            return View("Change", _manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(ScheduleModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.ProfessorList = _manager.GetProfessorList();
                    ViewBag.SubjectList = _manager.GetSubjectList();
                    return View(model);
                }
                _manager.Change(model);
                return RedirectToAction("Index", "Secretary");
            }
            catch
            {
                return RedirectToAction("Http500", "Error");
            }
        }
    }
}