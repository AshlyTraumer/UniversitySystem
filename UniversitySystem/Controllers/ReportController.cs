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
        public async  Task<ActionResult> Get()
        {
            /*  var pTask = new ProfessorQuery(new RepositoryContext()).GetAsync();
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

            var model = new CommonReportModel
            {
                SpecialityMinMaxModel = new SpecialityMinMaxQuery(Context).Get(2),
                AverageSubjectMarkModels = new AverageSubjectMarkQuery(Context).Get(),
                ProfessorQueryModels = new ProfessorQueryCache(Context).GetAllFromCache("professor_query"),
                TopEntrantModels = new TopEntrantCache(Context).GetAllFromCache("top_entrant")
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