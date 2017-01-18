using ClassLibrary;
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
    public class SubjectController : Controller
    {
        RepositoryContext _context;
        public SubjectController()
        {
            _context = new RepositoryContext();
            _context.Database.Log = LogMethod;
        }

        public void LogMethod(string str)
        {
            FileStream fs = new FileStream("e:\\UniversitySystem\\Subject.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(str);
            sw.Close();
            fs.Close();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new SubjectManager(_context).Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SubjectModel());
        }

        [HttpPost]
        public ActionResult Create(SubjectModel model)
        {
            new SubjectManager(_context).Create(model);
            return RedirectToAction("Index", "Subject");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new SubjectManager(_context).Delete(id);
            return RedirectToAction("Index", "Subject");
        }

        [HttpGet]
        public ActionResult Change(int id)
        {
            SubjectModel subject = new SubjectManager(_context).GetById(id);
            return View("Change", subject);
        }

        [HttpPost]
        public ActionResult Change(SubjectModel model)
        {
            new SubjectManager(_context).Change(model);
            return RedirectToAction("Index", "Subject");
        }
    }
}