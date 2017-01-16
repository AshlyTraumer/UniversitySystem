using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySystem.Controllers
{
    public class DepartamentController : Controller
    {
        // GET: Departament
        RepositoryContext context = new RepositoryContext();
        public User Check()
        {
            HttpCookie cookie = Request.Cookies["Cookie"];
            int coockieId = 0;
            if ((cookie == null) || (!Int32.TryParse(cookie["id"], out coockieId)))
                return null;
            User user = context.Users.FirstOrDefault(x => x.Id == coockieId);
            if ((user == null) || (user.Role != ClassLibrary.Authorization.Role.Secretary))
                return null;
            return user;
        }

        [Cookie]
        public ActionResult Index()
        {
            User cookie = Check();
           if (cookie == null)
                return Redirect("/Start");

            try
            {
                IEnumerable<Departament> departaments = context.Departaments;
                ViewBag.Id = cookie.Id;
                return View(departaments);
            }
            catch
            {
                ViewBag.Message = "Ошибка отображения данных";
                return Redirect("Error");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            User cookie = Check();
            if (cookie == null)
                return Redirect("/Start");
            try
            {
                ViewBag.Id = cookie.Id;                
                return View(new Departament());
            }
            catch
            {
                ViewBag.Message = "Ошибка отображения данных";
                return Redirect("Error");
            }
        }

        [HttpPost]
        public ActionResult Create(Departament p)
        {
            User cookie = Check();
            if (cookie == null)
                return Redirect("/Start");

            try
            {                
                context.Departaments.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index","Departament");
                //return View("Index", context.Departaments);
            }
            catch
            {
                ViewBag.Message = "Ошибка отображения данных";
                return Redirect("Error");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            User cookie = Check();
            if (cookie == null)
                return Redirect("/Start");

            try
            {
                Departament p = new Departament() { Id = id };
                context.Departaments.Attach(p);
                context.Departaments.Remove(p);
                context.SaveChanges();
                return RedirectToAction("Index", "Departament");
            }
            catch
            {
                return RedirectToAction("Index", "Departament");
            }
        }
    }
}