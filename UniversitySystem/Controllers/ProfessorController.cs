using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace UniversitySystem.Controllers
{
    public class ProfessorController : Controller
    {
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

        public ActionResult Index()
        {
            User cookie = Check();
            if (cookie == null)
                return Redirect("/Start");

            try
            {
                List<Professor> professors = context.Professors.Include(x => x.Departament).ToList();                
                ViewBag.Id = cookie.Id;
                return View(professors);
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
                Dictionary<int, string> dictionary = new Dictionary<int, string>();
                foreach (Departament d in context.Departaments)
                    dictionary.Add(d.Id, d.Title);
                ViewBag.Departaments = dictionary;
                return View(new Professor());
            }
            catch
            {
                ViewBag.Message = "Ошибка отображения данных";
                return Redirect("Error");
            }
        }

        [HttpPost]
        public ActionResult Create(Professor p)
        {
            User cookie = Check();
            if (cookie == null)
                return Redirect("/Start");

            try
            {
                p.Departament = context.Departaments.First(x => x.Id == p.DepartamentId);
                context.Professors.Add(p);
                context.SaveChanges();
                return View("Index", context.Professors.Include(x => x.Departament));
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
                Professor p = new Professor() { Id = id };
                context.Professors.Attach(p);
                context.Professors.Remove(p);
                context.SaveChanges();
                return View("Index", context.Professors.Include(x => x.Departament));
            }
            catch
            {
                return View("Index", context.Professors.Include(x => x.Departament));
            }
        }
    }
}