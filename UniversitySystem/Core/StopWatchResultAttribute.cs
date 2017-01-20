using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySystem.Core
{
    public class StopWatchResultAttribute : FilterAttribute, IResultFilter
    {
        private string _key = "StopWatch";
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var stopWatch = filterContext.HttpContext.Items[_key] as Stopwatch;
            stopWatch.Stop();
            var result = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            result.Hours, result.Minutes, result.Seconds, result.Milliseconds / 10);

            new LogService().WriteInfo("Result "+elapsedTime);
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            filterContext.HttpContext.Items[_key] = stopWatch;
        }
    }
}