using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

    }
}
