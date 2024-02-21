using Voting_API.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace Voting_API.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
		/// Adds the dbcontext to the service collection
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static IServiceCollection AddVotingApiDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<VotingApiDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Api"),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(VotingApiDbContext).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(5);
                    });
            });

            return services;
        }

        /// <summary>
		/// Set ups the routing and versioning
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection SetUpRoutes(this IServiceCollection services)
        {
            // configure route options
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });

            // register MVC services
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = ApiVersion.Default;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddMvc().AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        /// <summary>
		/// Adds the swagger to the ServiceCollection
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var contact = new OpenApiContact()
            {
                Name = "Lukas Vachtarcik",
                Email = "lukas.vachtarcik@gmail.com",
                Url = new Uri("https://github.com/vachty/Voting-API")
            };

            var title = "Voting service API";
            var version = "v1";

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = version,
                    Title = title + " V1",
                    Contact = contact
                });

                x.SwaggerDoc("v2", new OpenApiInfo()
                {
                    Version = version,
                    Title = title + " V2",
                    Contact = contact
                });

                var executingAssembly = Assembly.GetExecutingAssembly();
                x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{executingAssembly.GetName().Name}.xml"));

                var referencedProjectsXmlDocPaths = executingAssembly.GetReferencedAssemblies()
                    .Where(assembly => assembly.Name != null)
                    .Select(assembly => Path.Combine(AppContext.BaseDirectory, $"{assembly.Name}.xml"))
                    .Where(path => File.Exists(path));
                foreach (var xmlDocPath in referencedProjectsXmlDocPaths)
                {
                    x.IncludeXmlComments(xmlDocPath);
                }

                x.ResolveConflictingActions(apiDesc => apiDesc.First());
                x.DocInclusionPredicate((docName, apiDesc) => apiDesc.GroupName == docName);
            });

            return services;
        }

    }
}
