using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class RegisterController : Controller
    {
        public AuthorizeManager Manager
        {
            get
            {
                return new AuthorizeManager(HttpContext.GetContextPerRequest());
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Join(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Register(model);
                return RedirectToAction("Login", "Start");
            }            
            return View("Index",model);
        }
    }
}