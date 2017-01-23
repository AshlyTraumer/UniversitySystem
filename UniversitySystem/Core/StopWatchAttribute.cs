using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace UniversitySystem.Core
{
    public class StopWatchAttribute : FilterAttribute, IActionFilter
    {
        private const string Key = "StopWatch";

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var stopWatch = filterContext.HttpContext.Items[Key] as Stopwatch;

            if (stopWatch == null) return;
            stopWatch.Stop();

            var result = stopWatch.Elapsed;

            string elapsedTime = $"{result.Hours}:{result.Minutes}:{result.Seconds}.{result.Milliseconds / 10}";
            string message = $"Action {filterContext.HttpContext.Request.HttpMethod} {filterContext.HttpContext.Request.Url?.AbsoluteUri} Time: {elapsedTime}";
            new LogService().WriteInfo(message);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();            
            filterContext.HttpContext.Items[Key] = stopWatch;            
        }
    }
}