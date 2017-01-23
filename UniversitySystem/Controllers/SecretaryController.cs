using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class SecretaryController : Controller
    {
        public ScheduleManager Manager => new ScheduleManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Index()
        {
            return View(Manager.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ProfessorList = Manager.GetProfessorList();
            ViewBag.SubjectList = Manager.GetSubjectList();
            return View(new ScheduleModel());
        }

        [HttpPost]
        public ActionResult Create(ScheduleModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Create(model);
                return RedirectToAction("Index", "Secretary");
            }
            ViewBag.ProfessorList = Manager.GetProfessorList();
            ViewBag.SubjectList = Manager.GetSubjectList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Manager.Delete(id);
            return RedirectToAction("Index", "Secretary");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            ViewBag.ProfessorList = Manager.GetProfessorList();
            ViewBag.SubjectList = Manager.GetSubjectList();
            return View("Change", Manager.GetById(id));
        }

        [HttpPost]
        public ActionResult Change(ScheduleModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                Manager.Change(model);
                return RedirectToAction("Index", "Secretary");
            }
            catch
            {
                return RedirectToAction("Http500", "Error");
            }
        }
    }
}