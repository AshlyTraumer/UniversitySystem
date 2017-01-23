using System.IO;
using System.Web;
using ClassLibrary;
using System.Diagnostics;
using System;

namespace UniversitySystem.Core
{
    public static class HttpContextExtensions
    {
        public static RepositoryContext GetContextPerRequest(this HttpContextBase httpContext)
        {
            const string key = "RepositoryContext";           

            var context = httpContext.Items[key] as RepositoryContext;

            if (context != null) return context;
            context = new RepositoryContext();

            var path = Path.Combine(httpContext.Server.MapPath("~/Logs"), "Log.txt");

            context.Database.Log = str =>
            {
                using (var fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(str);
                    }
                }
            };

            httpContext.Items[key] = context;

            return context;
        }
    }
}