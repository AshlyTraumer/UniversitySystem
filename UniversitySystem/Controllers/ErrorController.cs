using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySystem.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ClientView()
        {
            return View();
        }

        public ActionResult ServerView()
        {
            return View();
        }
    }
}