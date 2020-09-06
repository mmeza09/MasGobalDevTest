using MasGobalDevTest.API.App_Start;
using MasGobalDevTest.BL;
using MasGobalDevTest.DA;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace MasGobalDevTest.API
{
    /// <summary>
    /// Application configuration class
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register configurations
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // DI
            var container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeService, EmployeeService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Disable Xml Formatter
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // configure json formatter
            //JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
            //jsonFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.UseDataContractJsonSerializer = true;
        }
    }
}
