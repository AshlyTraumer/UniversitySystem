using System.Web;
using System.Web.Mvc;
using UniversitySystem.Core;

namespace UniversitySystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           // filters.Add(new HandleErrorAttribute());
            filters.Add(new StopWatchAttribute());
            filters.Add(new StopWatchResultAttribute());            
        }
    }
}
