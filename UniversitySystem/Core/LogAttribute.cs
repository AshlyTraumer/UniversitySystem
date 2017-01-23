using System.Diagnostics;
using System.Web.Mvc;

namespace UniversitySystem.Core
{
    public class LogAttribute : ActionFilterAttribute
    {
        private const string Key = "StopWatch";

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var stopWatch = filterContext.HttpContext.Items[Key] as Stopwatch;

            if (stopWatch == null)
                return;

            stopWatch.Stop();

            var result = stopWatch.Elapsed;

            string elapsedTime = $"{result.Seconds}.{result.Milliseconds / 10}";
            string message = $"Action {filterContext.HttpContext.Request.HttpMethod} {filterContext.HttpContext.Request.Url?.AbsoluteUri} Time: {elapsedTime}";
            new LogService().WriteInfo(message);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            filterContext.HttpContext.Items[Key] = stopWatch;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var stopWatch = filterContext.HttpContext.Items[Key] as Stopwatch;

            if (stopWatch == null) return;
            stopWatch.Stop();

            var result = stopWatch.Elapsed;

            string elapsedTime =
                $"{result.Seconds}.{result.Milliseconds / 10}";

            new LogService().WriteInfo("Result " + elapsedTime);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            filterContext.HttpContext.Items[Key] = stopWatch;
        }
    }
}