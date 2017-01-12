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
            return View();
        }

        [HttpPost]
        public ActionResult Join(string login, string password, string role)
        {
            // или using
            try
            {
                RepositoryContext context = new RepositoryContext();
                User user = new User() { Login = login, Password = password };
                switch (role)
                {
                    case "Администратор": user.Role = Role.Admin; break;
                    case "Секретарь": user.Role = Role.Secretary; break;
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