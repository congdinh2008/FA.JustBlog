using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace FA.JustBlog.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Formatters
                .JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}
