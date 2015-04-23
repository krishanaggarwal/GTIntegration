using Nrgs.Adapter.Web.Api.Infrastructure.MesssageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Nrgs.Adapter.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
            RegisterHandlers();
        }

        private void RegisterHandlers()
        {
            GlobalConfiguration.Configuration.MessageHandlers.Add(
            new AuthenticationMessageHandler());
        }

        protected void Application_Error()
        { 
        }
    }
}
