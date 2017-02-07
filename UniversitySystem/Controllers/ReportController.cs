using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ClassLibrary;
using UniversitySystem.Cache;
using UniversitySystem.Core;
using UniversitySystem.Models.ReportModel;
using UniversitySystem.Report;


namespace UniversitySystem.Controllers
{
    public class ReportController : Controller
    {
        public RepositoryContext Context => HttpContext.GetContextPerRequest();

        // GET: Report
        public async Task<ActionResult> Get()
        {
            var cache = new AppCache(HttpContext.Cache);

            /* var pTask = new ProfessorQuery(new RepositoryContext()).GetAsync();
             var asmTask = new AverageSubjectMarkQuery(new RepositoryContext()).GetAsync();
             var smmTask = new SpecialityMinMaxQuery(new RepositoryContext()).GetAsync(2);
             var teTask = new TopEntrantQuery(new RepositoryContext()).GetAsync();

             await Task.WhenAll(pTask, asmTask, teTask, smmTask);

             return View(new CommonReportModel
             {
                 SpecialityMinMaxModel = smmTask.Result,
                 TopEntrantModels = teTask.Result,
                 AverageSubjectMarkModels = asmTask.Result,
                 ProfessorQueryModels = pTask.Result
             });*/


          /*  var model = new CommonReportModel
            {
                SpecialityMinMaxModel = cache.GetAllFromCache<int, SpecialityMinMaxModel>
                 (
                     "sreciality_min_max",
                     new SpecialityMinMaxQuery(Context).Get,
                     2
                 ),

                AverageSubjectMarkModels = cache.GetAllFromCache<List<AverageSubjectMarkModel>>
                 (
                     "average_mark",
                     new AverageSubjectMarkQuery(Context).Get
                 ),

                TopEntrantModels = cache.GetAllFromCache<List<TopEntrantModel>>
                (
                    "top_entrant",
                    new TopEntrantQuery(Context).Get
                ),

                ProfessorQueryModels = cache.GetAllFromCache<List<ProfessorQueryModel>>
                (
                    "professor_model",
                    new ProfessorQuery(Context).Get
                 )
            };*/
            

            var model = new CommonReportModel
            {
                AverageSubjectMarkModels = new DecoratorCache<AverageSubjectMarkModel>(new AverageSubjectMarkQuery(Context)).SetKey("asm").Get(),
                SpecialityMinMaxModel = cache.GetAllFromCache<int, SpecialityMinMaxModel>
                 (
                     "sreciality_min_max",
                     new SpecialityMinMaxQuery(Context).Get,
                     2
                 ),
                TopEntrantModels = new DecoratorCache<TopEntrantModel>(new TopEntrantQuery(Context)).SetKey("te").Get(),
                ProfessorQueryModels = new DecoratorCache<ProfessorQueryModel>(new ProfessorQuery(Context)).SetKey("pq").Get()
            };

            return View(model);
        }

        public ActionResult GetAjax()
        {
            return View();
        }

        public ActionResult TopEntrantPartial()
        // public JsonResult TopEntrantPartial()
        {
            return Json(new TopEntrantQuery(Context).Get(), JsonRequestBehavior.AllowGet);
            // return PartialView("_TopEntrantPartial", new TopEntrantQuery(Context).Get());
        }

        public ActionResult ProfessorQueryPartial()
        {
            return PartialView("_ProfessorQueryPartial", new ProfessorQuery(Context).Get());
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