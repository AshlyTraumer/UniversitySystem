using ClassLibrary;
using System.Web.Mvc;
using UniversitySystem.Manager;
using UniversitySystem.Models;
using UniversitySystem.Core;

namespace UniversitySystem.Controllers
{
    public class AdminController : Controller
    {
        private RepositoryContext _context;

        public RepositoryContext Context
        {
            get
            {
                return HttpContext.GetContextPerRequest();
            }
        }        

        [HttpGet]
        public ActionResult Index()
        {
            return View(new UserManager(Context).Get());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new UserManager(Context).Delete(id);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            UserModel user = new UserManager(Context).GetById(id);
            return View("Change", user);
        }

        [HttpPost]
        public ActionResult Change(UserModel model)
        {
            if (ModelState.IsValid)
            {
                new UserManager(Context).Change(model);
                return RedirectToAction("Index", "Admin");
            }
            return View(model);
        }
    }
}