using CayuseWebAPI.APIs;
using CayuseWebAPI.APIs.Interfaces;
using CayuseWebAPI.APIs.RESTAPIs.Interfaces;
using CayuseWebAPI.Logging;
using CayuseWebAPI.Shared.RESTAPIs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace CayuseWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            container.RegisterType<IRestClientFactory, RestClientFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IRestRequestFactory, RestRequestFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IGooglePlacesAPI, GooglePlacesAPI>(new HierarchicalLifetimeManager());
            container.RegisterType<IWeatherAPI, WeatherAPI>(new HierarchicalLifetimeManager());
            container.RegisterType<IErrorLogger, ErrorLogger>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
