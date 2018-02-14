using Cobloga.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Cobloga.WebUI.App_Start;
using System.Web.Optimization;

namespace Cobloga.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DummyInitializationMethod();
        }

        private void DummyInitializationMethod()
        {
            using (var context = new CoblogaDataContext())
            {
                var posts =  context.CbaPost.ToList();
            }
        }
    }
}
