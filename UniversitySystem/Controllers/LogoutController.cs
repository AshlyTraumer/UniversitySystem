using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;

namespace UniversitySystem.Controllers
{
    public class LogoutController : Controller
    {
        
        [HttpGet]        
        public ActionResult Index()
        {
            /*RepositoryContext context = new RepositoryContext();
            HttpCookie cookie = Request.Cookies["Cookie"];
            int coockieId = 0;
            if ((cookie == null) || (!Int32.TryParse(cookie["id"], out coockieId)))
                return Redirect("/Start");
            User user = context.Users.FirstOrDefault(x => x.Id == coockieId);
            if (user == null)
                return Redirect("/Start");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);*/
            return RedirectToAction("Index","Start");
        }
    }
}