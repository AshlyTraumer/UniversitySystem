using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Manager;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class RegisterController : Controller
    {
        RepositoryContext _context;
        public RegisterController()
        {
            _context = new RepositoryContext();
            _context.Database.Log = LogMethod;
        }

        public void LogMethod(string str)
        {
            FileStream fs = new FileStream("e:\\UniversitySystem\\Register.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(fs);
            sw.Close();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Join(RegisterModel model)
        {
            new AuthorizeManager(_context).Register(model);
            return RedirectToAction("Login", "Start");

        }
    }
}