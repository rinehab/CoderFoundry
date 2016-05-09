using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace CoderFoundry.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// Registers this instance.
        /// </summary>
        public static void Register()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();

            // Register all ApiControllers with DI container
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => !t.IsAbstract && typeof(Controller).IsAssignableFrom(t))
                .InstancePerRequest();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyTypes(
                            Assembly.Load("CoderFoundry"),
                            Assembly.Load("CoderFoundry.HCL2Services")
                )
                .Where(
                    t =>
                        t.IsClass && t.GetInterfaces().Any())
                .As(t => t.GetInterfaces()).InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}