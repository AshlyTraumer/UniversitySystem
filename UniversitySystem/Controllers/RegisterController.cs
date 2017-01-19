using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Core;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class RegisterController : Controller
    {
        private RepositoryContext _context;
        public RepositoryContext Context
        {
            get
            {
                _context = HttpContext.GetContextPerRequest();
                return _context;
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
                new AuthorizeManager(Context).Register(model);
                return RedirectToAction("Login", "Start");
            }            
            return View("Index",model);
        }
    }
}