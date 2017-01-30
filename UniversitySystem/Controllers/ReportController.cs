﻿using System.Collections.Generic;
using System.Web.Mvc;
using ClassLibrary;
using UniversitySystem.Core;
using UniversitySystem.Models.ReportModel;
using UniversitySystem.Report;

namespace UniversitySystem.Controllers
{
    public class ReportController : Controller
    {
        public RepositoryContext Context => HttpContext.GetContextPerRequest();

        // GET: Report
        public ActionResult Get()
        {
            
            return View(new CommonReportModel
            {
                SpecialityMinMaxModel = new SpecialityMinMaxQuery(Context).Get(2),
                TopEntrantModels = new TopEntrantQuery(Context).Get(),
                AverageSubjectMarkModels = new AverageSubjectMarkQuery(Context).Get(),
                ProfessorQueryModels = new ProfessorQuery(Context).Get()
            });
        }

        public ActionResult GetAjax()
        {

            return View(new CommonReportModel
            {
                SpecialityMinMaxModel = new SpecialityMinMaxQuery(Context).Get(2),
                TopEntrantModels = new TopEntrantQuery(Context).Get(),
                AverageSubjectMarkModels = new AverageSubjectMarkQuery(Context).Get(),
                ProfessorQueryModels = new ProfessorQuery(Context).Get()
            });
        }

        public ActionResult TopEntrantPartial()
       // public JsonResult TopEntrantPartial()
        {
            //return Json(new TopEntrantQuery(Context).Get(), JsonRequestBehavior.AllowGet);
            return PartialView("_TopEntrantPartial", new TopEntrantQuery(Context).Get());
        }

        public ActionResult ProfessorQueryPartial( )
        {
            return PartialView("_ProfessorQueryPartial",new ProfessorQuery(Context).Get());
        }

        public ActionResult AverageSubjectMarkPartial()
        {
            return PartialView("_AverageSubjectMarkPartial", new AverageSubjectMarkQuery(Context).Get());
        }

        public ActionResult SpecialityMinMaxPartial()
        {
            return PartialView("_SpecialityMinMaxPartial", new SpecialityMinMaxQuery(Context).Get(2));
        }
    }
}