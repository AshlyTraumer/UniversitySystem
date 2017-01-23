using System.Web.Mvc;
using UniversitySystem.Manager;
using UniversitySystem.Models;
using UniversitySystem.Core;

namespace UniversitySystem.Controllers
{
    public class AdminController : Controller
    {
        public UserManager Manager => new UserManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Index()
        {
            return View(Manager.Get());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Manager.Delete(id);
                return RedirectToAction("Index", "Admin");
            }
            catch
            {
                return RedirectToAction("Http500", "Error");
            }
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            var user = Manager.GetById(id);
            return View("Change", user);
        }

        [HttpPost]
        public ActionResult Change(UserModel model)
        {
            if (!ModelState.IsValid) return View(model);
            Manager.Change(model);
            return RedirectToAction("Index", "Admin");
        }
    }
}