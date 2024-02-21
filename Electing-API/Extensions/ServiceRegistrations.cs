using Electing_API.Database;
using Electing_API.Database.EntityConfigs.Election;
using Electing_API.Database.Repositories.Election;
using Microsoft.EntityFrameworkCore;

namespace Electing_API.Extensions
{
    public static class ServiceRegistrations
    {
        /// <summary>
		/// Register the components
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //entity configs
            services.AddScoped<IElectionEntityConfig, ElectionEntityConfig>();

            //repositories
            services.AddScoped<IElectionRepository, ElectionRepository>();

            //dbcontext
            services.AddScoped<DbContext, ElectionApiDbContext>();

            return services;
        }
    }
}
