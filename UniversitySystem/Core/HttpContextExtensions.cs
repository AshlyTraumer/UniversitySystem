using System.IO;
using System.Web;
using ClassLibrary;
using UniversitySystem.Manager;

namespace UniversitySystem.Core
{
    public static class HttpContextExtensions
    {
        public static RepositoryContext GetContextPerRequest(this HttpContextBase httpContext)
        {
            var key = "RepositoryContext";

            var context = httpContext.Items[key] as RepositoryContext;

            if (context == null)
            {
                context = new RepositoryContext();

                //httpContext.Server.MapPath("~/Log/");

                context.Database.Log = str =>
                {
                    FileStream fs = new FileStream("e:\\UniversitySystem\\Departament.txt", FileMode.Append,
                        FileAccess.Write);
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