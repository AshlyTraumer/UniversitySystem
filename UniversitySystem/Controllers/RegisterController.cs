using System.Runtime.Caching;
using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class RegisterController : Controller
    {
        private AuthorizeManager _manager => new AuthorizeManager(HttpContext.GetContextPerRequest());

        [HttpGet]
        public ActionResult Index()
        {
           // MemoryCache.Default.Remove("professor_query");
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Join(RegisterModel model)
        {
            if (!ModelState.IsValid) return View("Index", model);
            _manager.Register(model);
            
            return RedirectToAction("Login", "Start");
        }
    }
}