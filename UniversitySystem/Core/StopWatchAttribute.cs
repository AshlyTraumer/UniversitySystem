using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace UniversitySystem.Core
{
    public class StopWatchAttribute : FilterAttribute, IActionFilter
    {
        private string _key = "StopWatch";
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var stopWatch = filterContext.HttpContext.Items[_key] as Stopwatch;
            stopWatch.Stop();
            var result = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:}:{1:}:{2:}.{3:}",
            result.Hours, result.Minutes, result.Seconds, result.Milliseconds / 10);

            new LogService().WriteInfo("Action "+filterContext.HttpContext.Request.Url.AbsolutePath+ " "+elapsedTime);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();            
            filterContext.HttpContext.Items[_key] = stopWatch;            
        }
    }
}