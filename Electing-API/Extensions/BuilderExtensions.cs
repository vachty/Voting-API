using Electing_API.Database;
using Microsoft.EntityFrameworkCore;

namespace Electing_API.Extensions
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
                using (var context = serviceScope.ServiceProvider.GetRequiredService<ElectionApiDbContext>())
                {
                    context.Database.Migrate();
                }
            }

            return app;
        }

        /// <summary>
		/// Set ups the swagger
		/// </summary>
		/// <param name="app"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static WebApplication SetSwaggerUI(this WebApplication app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint($"/swagger/v1/swagger.json", Constants.Constants.ApiTitleV1);
                });
            }

            return app;
        }
    }
}
