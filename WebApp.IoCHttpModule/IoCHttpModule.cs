using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using ProjectIoC.Library;
using ProjectIoC.Logger;
using ProjectIoC.LoggerConsole;
using ProjectIoC.Datasource;
using ProjectIoC.Datasource.Memory;
using System.Web.UI;

namespace WebApp.IoC
{
    public class IoCHttpModule : IHttpModule
    {
        private static readonly IContainer MyContainer;

        static IoCHttpModule()
        {

            StructureMap.Container container = new StructureMap.Container((r) =>
            {
                r.For<IOrderService>().Use<OrderService>();
                r.For<IExternalOrderService>().Use<ExternalOrderService>();


                // r.For<ProjectIoC.Datasource.IDataSource>().Use<DatasourceMemory>().Singleton().Ctor<ILogger>("logger").Is<LoggerConsole>();
                r.For<ProjectIoC.Datasource.IDataSource>().Use<DatasourceMemory>().Singleton().Ctor<ILogger>("logger").Is<LoggerDebugTrace>(q => q.Ctor<string>("source").Is("datasource"));
                r.Policies.FillAllPropertiesOfType<ILogger>().Use<LoggerDebugTrace>().Ctor<string>("source").Is("web").Named("Logger-web");
                r.For<ILogger>().Use("Logger-web"); //Use<LoggerDebugTrace>().Ctor<string>("source").Is("default");
                
            });
            MyContainer = container;

        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += Context_PreRequestHandlerExecute;
        }

        public void Dispose() { }

        private void Context_PreRequestHandlerExecute(object sender, EventArgs e)
        {

            var page = HttpContext.Current.CurrentHandler as Page;

            if (page == null) return;

            // Get the code-behind class that we may have written
            var pageType = page.GetType().BaseType;

            // Determine if there is a constructor to inject, and grab it
            var ctor = (from c in pageType.GetConstructors()
                        where c.GetParameters().Length > 0
                        select c).FirstOrDefault();

            if (ctor != null)
            {

                // Resolve the parameters for the constructor
                var args = (from parm in ctor.GetParameters()
                            select MyContainer.GetInstance(parm.ParameterType))
                            .ToArray();

                // Execute the constructor method with the arguments resolved
                ctor.Invoke(page, args);

            }

            // Set properties
            MyContainer.BuildUp(page);

        }
    }
}
