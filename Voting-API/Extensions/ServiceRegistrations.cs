using Voting_API.Database;
using Voting_API.Database.EntityConfigs.Candidate;
using Voting_API.Database.Repositories.Candidate;
using Microsoft.EntityFrameworkCore;

namespace Voting_API.Extensions
{
    /// <summary>
    /// The ServiceRegistrations extension
    /// </summary>
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