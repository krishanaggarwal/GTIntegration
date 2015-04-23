using Microsoft.Practices.Unity;
using NaGreen.WebApi.Common.Configuration;
using NaGreen.WebApi.Server.Base.Business;
using NaGreen.WebApi.Server.Base.Facade;
using NaGreen.WebApi.Server.Base.Repositories;
using NaGreen.WebApi.Server.Base.Services;
using NaGreen.WebApi.Server.Implementation.Business;
using NaGreen.WebApi.Server.Implementation.Facade;
using NaGreen.WebApi.Server.Implementation.Repositories;
using NaGreen.WebApi.Server.Implementation.Services;
using System.Web.Http;
using Unity.WebApi;

namespace NaGreenWebApi
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
            unityContainer.RegisterType<IConfigurationProvider, ConfigurationProvider>(new HierarchicalLifetimeManager());

            unityContainer.RegisterType<IUsersRepository, UsersRepository>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IUsersBl, UsersBl>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IUsersFacade, UsersFacade>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IUsersService, UsersService>(new HierarchicalLifetimeManager());
        }
    }
}