using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using ProjectIoC.Library;
using ProjectIoC.Logger;
using ProjectIoC.LoggerConsole;
using ProjectIoC.Datasource;
using ProjectIoC.Datasource.Memory;

namespace WebApp
{


    public class Global : HttpApplication
    {

        public static StructureMap.Container MyContainer;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            StructureMap.Container container = new StructureMap.Container((r) =>
            {
                r.For<IOrderService>().Use<OrderService>();
                r.For<ILogger>().Use<LoggerConsole>();
                r.For<IDataSource>().Use<DatasourceMemory>().Singleton();
            });
            MyContainer = container;

        }
    }
}