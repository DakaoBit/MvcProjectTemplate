using MessageHelper;
using MvcProjectTemplate.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcProjectTemplate
{
          public class MvcApplication : System.Web.HttpApplication
          {
                    protected void Application_Start()
                    {
                              AreaRegistration.RegisterAllAreas();
                              GlobalConfiguration.Configure(WebApiConfig.Register);
                              FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                              RouteConfig.RegisterRoutes(RouteTable.Routes);
                              BundleConfig.RegisterBundles(BundleTable.Bundles);

                              // log4net
                              var log4netPath = Server.MapPath("~/log4net.config");
                              log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(log4netPath));

                              // request-respones log
                              //GlobalConfiguration.Configuration.MessageHandlers.Add(new MessageLoggingHandler());

                              // 修正 ASP.NET Web API 的 XmlFormatter 所支援的媒體類型(MediaType)
                              GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
                    }
          }
}
