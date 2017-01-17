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
using UniversitySystem.Manager;
using UniversitySystem.Models;
using System.IO;

namespace UniversitySystem.Controllers
{
    public class AdminController : Controller
    {
        RepositoryContext _context;
        public AdminController()
        {
            _context = new RepositoryContext();
            _context.Database.Log = LogMethod;
        }

        public void LogMethod(string str)
        {
            FileStream fs = new FileStream("e:\\UniversitySystem\\Admin.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(str);
            sw.Close();
        }

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

        [HttpGet]
        public ActionResult Index()
        {
            return View(new UserManager(_context).Get());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new UserManager(_context).Delete(id);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            UserModel user = new UserManager(_context).GetById(id);
            return View("Change", user);
        }

        [HttpPost]
        public ActionResult Change(UserModel model)
        {
            new UserManager(_context).Change(model);
            return RedirectToAction("Index", "Admin");
        }
    }
}