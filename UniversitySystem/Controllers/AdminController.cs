using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using UniversitySystem;

namespace UniversitySystem.Controllers
{
    public class AdminController : Controller
    {
        RepositoryContext context = new RepositoryContext();
        //??????
        public User Check()
        {
            HttpCookie cookie = Request.Cookies["Cookie"];
            int coockieId = 0;
            if ((cookie == null) || (!Int32.TryParse(cookie["id"], out coockieId)))
                return null;
            User user = context.Users.FirstOrDefault(x => x.Id == coockieId);
            if ((user == null)||(user.Role!=ClassLibrary.Authorization.Role.Admin))
                return null;
            return user;                
        }

        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            User cookie = Check();
            if (cookie == null)
                return Redirect("/Start");

            try
            {
                IEnumerable<User> users = context.Users;                
                ViewBag.Id = cookie.Id;
                return View(users);
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
            if (cookie==null)
                return Redirect("/Start");

            try
            {
                User user = context.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    if (user.Role == Role.Admin)
                        return Redirect("/Start");
                    context.Users.Remove(user);
                    context.SaveChanges();
                    return Redirect("/Admin/Index/" + cookie.Id);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                ViewBag.Message = "Ошибка отображения данных";
                return Redirect("Error");
            }
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            User cookie = Check();
            if (cookie == null)
                return Redirect("/Start");

            try
            {
                User user = context.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    ViewBag.Id = cookie.Id;
                    return View("Change", user);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                ViewBag.Message = "Ошибка отображения данных";
                return Redirect("Error");
            }
        }

        [HttpPost]
        public ActionResult Change(User user)
        {
            // или using
            try
            {                 
                switch (user.Role)
                {
                    case Role.Admin: user.Role = Role.Admin; break;
                    case Role.Secretary: user.Role = Role.Secretary; break;
                }
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                IEnumerable<User> users = context.Users;                
                HttpCookie cookie = Request.Cookies["Cookie"];
                ViewBag.Id = cookie["id"];
                return View("Index", users);
            }
            catch
            {
                ViewBag.Message = "Ошибка регистрации";
                return Redirect("Error");
            }            
        }
    }
}