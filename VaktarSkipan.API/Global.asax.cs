using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace VaktarSkipan.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Context.Response.ClearHeaders();
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:1430");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            
        }
        protected void Application_Start()
        {
           /* var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.All;*/
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

    }
}
