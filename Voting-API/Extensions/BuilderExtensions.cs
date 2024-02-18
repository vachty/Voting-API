using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Voting_API.Extensions
{
    public static class BuilderExtensions
    {
        /// <summary>
		/// Use and apply the migrations to the database
		/// </summary>
		/// <param name="app"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static WebApplication UseMigrations(this WebApplication app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<VotingApiDbContext>())
                {
                    context.Database.Migrate();
                }
            }

            return app;
        }
    }
}
