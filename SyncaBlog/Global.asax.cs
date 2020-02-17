using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SyncaBlog.Ninject1;
using Ninject;
using Ninject.Web.Mvc;
using SyncaBlog.Core.EF;
using System.Data.Entity;


namespace SyncaBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new DbInitializer());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // внедрение зависимостей
            //NinjectModule registrationFirst = new NinjectRegistration();
            //NinjectModule registrationSecond = new BusinessNinjectRegistration(("EFDbContext"));
            //var kernel = new StandardKernel(registrationFirst,registrationSecond);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            //для 2 рівневої
            NinjectModule registrationFirst = new NinjectRegistration(("EFDbContext"));
            var kernel = new StandardKernel(registrationFirst);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));


        }
    }
}
