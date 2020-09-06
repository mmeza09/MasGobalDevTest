using System.Web.Http;
using WebActivatorEx;
using MasGobalDevTest.API;
using Swashbuckle.Application;
using System;
using System.Reflection;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MasGobalDevTest.API
{
    /// <summary>
    /// Swagger configuration class
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Register swagger 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory+"bin\\";
                        var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                        var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                        c.SingleApiVersion("v1", "MasGobalDevTest API");
                        c.IncludeXmlComments(commentsFile);

                    })
                .EnableSwaggerUi();
        }
    }
}
