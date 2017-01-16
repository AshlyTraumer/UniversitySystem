using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.DAO;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register  
        [AllowAnonymous]   
        public ActionResult Index()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Join(RegisterModel model)
        {
             new AuthorizeDAO().Register(model);
               // ViewBag.Message="Регистрация прошла успешно";
            return RedirectToAction("Login", "Start");
                      
        }
    }
}