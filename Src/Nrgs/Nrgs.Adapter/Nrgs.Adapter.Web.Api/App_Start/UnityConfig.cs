using Microsoft.Practices.Unity;
using Nrgs.Adapter.Common.Configuration;
using Nrgs.Adapter.Server.Base.Business;
using Nrgs.Adapter.Server.Base.Facade;
using Nrgs.Adapter.Server.Base.Repositories;
using Nrgs.Adapter.Server.Base.Services;
using Nrgs.Adapter.Server.Implementation.Business;
using Nrgs.Adapter.Server.Implementation.Facade;
using Nrgs.Adapter.Server.Implementation.Repositories;
using Nrgs.Adapter.Server.Implementation.Services;
using Nrgs.Adapter.Web.Api.Infrastructure;
using System.Web.Http;
using Unity.WebApi;

namespace Nrgs.Adapter.Web.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            RegisterDependencies(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static void RegisterDependencies(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IHttpContextService, HttpContextService>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType(typeof(IRestClient<>), typeof(RestClient<>), new HierarchicalLifetimeManager());
            unityContainer.RegisterType<INrgsConfigurations, NrgsConfigurations>(new HierarchicalLifetimeManager());

            unityContainer.RegisterType<IArticlesRepository, ArticlesRepository>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IArticlesBl, ArticlesBl>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IArticlesFacade, ArticlesFacade>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IArticlesService, ArticlesService>(new HierarchicalLifetimeManager());
        }
    }
}