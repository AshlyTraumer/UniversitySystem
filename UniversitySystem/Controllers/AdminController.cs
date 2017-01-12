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
            if (user == null)
                return null;
            return user;                
        }

        // GET: Admin
        [HttpGet]
        public ActionResult Index(int id)
        {
            User cookie = Check();
            if (cookie == null)
                return Redirect("/Start");

            try
            {
                IEnumerable<User> users = context.Users;
                ViewBag.Users = users;
                ViewBag.Id = id;
                return View();
            }
            catch (Exception e)
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
                    ViewBag.User = user;
                    return View("Change");
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
        public ActionResult Change(string id,string login, string password, string role)
        {
            // или using
            try
            {                            
                User user = new User() { Login = login, Password = password, Id= Int32.Parse(id) };
                switch (role)
                {
                    case "Администратор": user.Role = Role.Admin; break;
                    case "Секретарь": user.Role = Role.Secretary; break;
                }
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                IEnumerable<User> users = context.Users;
                ViewBag.Users = users;
                HttpCookie cookie = Request.Cookies["Cookie"];
                ViewBag.Id = cookie["id"];
            }
            catch
            {
                ViewBag.Message = "Ошибка регистрации";
            }
            return View("Index");
        }
    }
}