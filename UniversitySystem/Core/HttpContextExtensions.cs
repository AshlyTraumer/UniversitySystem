using System.IO;
using System.Web;
using ClassLibrary;
using UniversitySystem.Manager;

namespace UniversitySystem.Core
{
    public static class HttpContextExtensions
    {
        public static RepositoryContext GetContextPerRequest(this HttpContextBase httpContext,string fileName)
        {
            var key = "RepositoryContext";

            var context = httpContext.Items[key] as RepositoryContext;

            if (context == null)
            {
                context = new RepositoryContext();

                var path=Path.Combine(httpContext.Server.MapPath("~/Logs"), fileName);

                context.Database.Log = str =>
                {
                    FileStream fs = new FileStream(path, FileMode.Append,FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(str);
                    sw.Close();
                    fs.Close();
                };

                httpContext.Items[key] = context;
            }

            return context;
        }
    }
}