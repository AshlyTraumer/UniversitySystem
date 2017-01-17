using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using UniversitySystem;
using UniversitySystem.Models;
using UniversitySystem.Manager;
using System.IO;

namespace UniversitySystem.Controllers
{
    public class StartController : Controller
    {
        RepositoryContext _context;
        public StartController()
        {
            _context = new RepositoryContext();
            _context.Database.Log = LogMethod;
        }

        public void LogMethod(string str)
        {
            FileStream fs = new FileStream("e:\\UniversitySystem\\Start.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(str);            
            sw.Close();
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        //HttpCookie cookie = new HttpCookie("Cookie");        

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            //  var claimsIdentity = new ClaimsIdentity();
            //   claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            //  claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));
            //  AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, claimsIdentity);

            UserModel user = new AuthorizeManager(_context).Login(model);
            switch (user.Role)
            {
                case Role.Admin: return RedirectToAction("Index", "Admin");
                case Role.Secretary: return RedirectToAction("Index", "Secretary");
                default: return RedirectToAction("Index", "Admin");
            }

            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}