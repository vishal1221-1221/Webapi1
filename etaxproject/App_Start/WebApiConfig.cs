using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;
using System.Data.Entity;
namespace etaxproject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
               new MediaTypeHeaderValue("text/html"));
            
          
            System.Web.Http.Cors.EnableCorsAttribute cors = new System.Web.Http.Cors.EnableCorsAttribute("*","*","*");
            config.EnableCors(cors);
        }
    }
}
