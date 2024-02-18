using Infrastructure.Database;
using Infrastructure.Database.EntityConfigs.Candidate;
using Infrastructure.Database.Repositories.Candidate;
using Microsoft.EntityFrameworkCore;

namespace Voting_API.Extensions
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

            //repositories
            services.AddScoped<ICandidateRepository, CandidateRepository>();

            //dbcontext
            services.AddScoped<DbContext, VotingApiDbContext>();

            return services;
        }
    }
}
