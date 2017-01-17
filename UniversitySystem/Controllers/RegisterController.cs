using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class RegisterController : Controller
    {
        private RepositoryContext context;
        public RegisterController()
        {
            context = new RepositoryContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Join(RegisterModel model)
        {
            new AuthorizeManager(context).Register(model);
            return RedirectToAction("Login", "Start");

        }
    }
}