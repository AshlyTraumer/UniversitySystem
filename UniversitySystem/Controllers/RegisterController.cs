using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySystem.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register     
        public ActionResult Index()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Join(User user)
        {
            // или using
            try
            {
               RepositoryContext context = new RepositoryContext();               
                switch (user.Role)
                {
                    case Role.Admin: user.Role = Role.Admin; break;
                    case Role.Secretary: user.Role = Role.Secretary; break;
                }
                context.Users.Add(user);
                context.SaveChanges();
                ViewBag.Message="Регистрация прошла успешно";
            }
            catch
            {
                ViewBag.Message = "Ошибка регистрации";
            }
            return View();           
        }
    }
}