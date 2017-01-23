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
        private const string Key = "StopWatch";

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var stopWatch = filterContext.HttpContext.Items[Key] as Stopwatch;

            if (stopWatch == null) return;
            stopWatch.Stop();

            var result = stopWatch.Elapsed;

            string elapsedTime =
                $"{result.Hours}:{result.Minutes}:{result.Seconds}.{result.Milliseconds / 10}";

            new LogService().WriteInfo("Result "+elapsedTime);
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            filterContext.HttpContext.Items[Key] = stopWatch;
        }
    }
}