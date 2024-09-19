using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BetterRental1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           // var cors = new EnableCorsAttribute("*", "*", "*");
        //    var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
