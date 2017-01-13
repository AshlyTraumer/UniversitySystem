using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem;

namespace UniversitySystem.Controllers
{
    public class StartController : Controller
    {
        // GET: Start      
        HttpCookie cookie = new HttpCookie("Cookie");
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            // или using
            try
            {
                RepositoryContext context = new RepositoryContext();
                User user= context.Users.FirstOrDefault(x => x.Login == u.Login && x.Password == u.Password);
                switch (user?.Role)
                {
                    case Role.Admin:                        
                        cookie["id"] = user.Id.ToString();
                        Response.Cookies.Add(cookie);
                        return Redirect("/Admin/Index/" + user.Id);
                    case Role.Secretary:                        
                        cookie["id"] = user.Id.ToString();
                        Response.Cookies.Add(cookie);
                        return Redirect("/Secretary/Index/" + user.Id);
                    default:
                        throw new Exception();
                }                
            }
            catch
            {
                ViewBag.Message = "Ошибка регистрации";                
                return View("Index");
            }            
        }
    }
}