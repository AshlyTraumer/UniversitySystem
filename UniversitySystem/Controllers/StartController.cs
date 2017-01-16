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
using UniversitySystem.DAO;

namespace UniversitySystem.Controllers
{
    public class StartController : Controller
    {

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Start      
        //HttpCookie cookie = new HttpCookie("Cookie");
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            //  var claimsIdentity = new ClaimsIdentity();
            //   claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            //  claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));
            //  AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, claimsIdentity);

            User user = new AuthorizeDAO().Login(model);            
                switch (user.Role)
                {
                    case Role.Admin: return RedirectToAction("Index", "Admin");
                    case Role.Secretary: return RedirectToAction("Index", "Secretary");
                }
                return RedirectToAction("Index", "Admin");
            
            
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            /* RepositoryContext context = new RepositoryContext();
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
             }   */

        }
    }
}