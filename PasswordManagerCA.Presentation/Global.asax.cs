using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PasswordManager.Presentation.App_Start;

namespace PasswordManager.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            IoCConfigurator.ConfigureDependencyInjection();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
