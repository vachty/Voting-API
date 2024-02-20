using Infrastructure.Database;
using Infrastructure.Database.EntityConfigs.Candidate;
using Infrastructure.Database.EntityConfigs.Election;
using Infrastructure.Database.Repositories.Candidate;
using Infrastructure.Database.Repositories.Election;
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
            services.AddScoped<ICandidateEntityConfig, CandidateEntityConfig>();
            services.AddScoped<IElectionEntityConfig, ElectionEntityConfig>();

            //repositories
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IElectionRepository, ElectionRepository>();

            //dbcontext
            services.AddScoped<DbContext, VotingApiDbContext>();

            return services;
        }
    }
}
