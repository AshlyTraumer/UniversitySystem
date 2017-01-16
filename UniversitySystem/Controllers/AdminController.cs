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
using System.Security.Claims;
using UniversitySystem.DAO;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class AdminController : Controller
    {
        RepositoryContext context = new RepositoryContext();
        //??????
        /* public User Check()
         {
             HttpCookie cookie = Request.Cookies["Cookie"];
             int coockieId = 0;
             if ((cookie == null) || (!Int32.TryParse(cookie["id"], out coockieId)))
                 return null;
             User user = context.Users.FirstOrDefault(x => x.Id == coockieId);
             if ((user == null)||(user.Role!=ClassLibrary.Authorization.Role.Admin))
                 return null;
             return user;                
         }*/

        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View(new UserDAO().Get());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            User user = new UserDAO().GetById(id);
            if (user != null)
                return View("Change", user);
            else
                return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public ActionResult Change(User model)
        {
            new UserDAO().Change(model);            
            return RedirectToAction("Index","Admin");
        }
    }
}