using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using ClassLibrary;
using UniversitySystem.Controllers;
using UniversitySystem.Core;
using UniversitySystem.Core.Csvs;
using UniversitySystem.Core.Csvs.Interfaces;
using UniversitySystem.Models;

namespace UniversitySystem
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(ScheduleModel), new DateTimeModelBinder());

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            builder.RegisterInstance(new RepositoryContext()).As<RepositoryContext>();
            builder.RegisterType<CommonRepository>().As<ICommonRepository>().InstancePerRequest();

            builder.RegisterType<CsvHelper>().As<ICsvHelper>();
            builder.RegisterType<CsvZipper>().As<ICsvZipper>();
            builder.RegisterType<CsvWrapper>().As<ICsvWrapper>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
        }

        private void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            if (exception == null)
                return;

            var httpException = exception as HttpException;
            var status = httpException?.ErrorCode ?? 500;

            new LogService().WriteError(exception.Message);
                                    
            Server.ClearError();

            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = "Http" + status;
            
            IController errorsController = new ErrorController();
            var wrapper = new HttpContextWrapper(Context);
            var rc = new RequestContext(wrapper, routeData);
            errorsController.Execute(rc);
        }
    }
}
