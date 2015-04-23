using Microsoft.Practices.Unity;
using Nrgs.Adapter.Web.Api.Infrastructure;
using Nrgs.Adapter.Web.Api.Infrastructure.ExceptionHandlers;
using Nrgs.Adapter.Web.Api.Infrastructure.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using Unity.WebApi;
using Nrgs.Adapter.Server.Base.Services;
using Nrgs.Adapter.Server.Implementation.Services;
using Nrgs.Adapter.Common.Configuration;

namespace Nrgs.Adapter.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof
            (ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintsResolver);

            config.Services.Replace(typeof(IHttpControllerSelector),
            new NamespaceHttpControllerSelector(config));

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        }


    }
}
