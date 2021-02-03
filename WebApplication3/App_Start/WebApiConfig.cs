using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiContrib.Formatting.Jsonp;

namespace WebApplication3
{
    public static class WebApiConfig
    {
        //  return JSON instead of XML from ASP.NET Web API Service when a request is made from the browser.#2

        //public class CustomJsonFormatter : JsonMediaTypeFormatter
        //{
        //    public CustomJsonFormatter()
        //    {
        //        this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        //    }

        //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        //    {
        //        base.SetDefaultContentHeaders(type, headers, mediaType);
        //        headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    }
        //}

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

            config.Filters.Add(new RequireHttpsAttribute());

            // so we can use Cross origin resource sharing * means inlcude every option
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
         //   config.EnableCors(cors);
            config.EnableCors();

            // so we can call Web API service in a cross domain using jQuery ajax
            //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, jsonpFormatter);


            //continuation of line 16
            //    config.Formatters.Add(new CustomJsonFormatter());

            //  return JSON instead of XML from ASP.NET Web API Service when a request is made from the browser #1. 
            //config.Formatters.JsonFormatter.SupportedMediaTypes
            //.Add(new MediaTypeHeaderValue("text/html"));

            // supporting only json and not xml
            //   config.Formatters.Remove(config.Formatters.XmlFormatter);

            // to indend the sending data properly we do:
            //   config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            // Camel case instead of Pascal case
            //   config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
  