using Electing_API.Database.EntityConfigs.Election;
using Microsoft.EntityFrameworkCore;
using Electing_API.Database.Domain.Dbo;

namespace Electing_API.Database
{
    public class ElectionApiDbContext : DbContext, IElectionApiDbContext
    {
        /// <summary>
        /// The election entity config
        /// </summary>
        private readonly IElectionEntityConfig electionEntityConfig;

        /// <summary>
        /// Creates instance of the database context
        /// </summary>
        /// <param name="electionEntityConfig"></param>
        /// <param name="options"></param>
        public ElectionApiDbContext(
            IElectionEntityConfig electionEntityConfig,
            DbContextOptions<ElectionApiDbContext> options) : base(options)
        {
            this.electionEntityConfig = electionEntityConfig;
        }

        /// <inheritdoc/>
        public DbSet<Election> Elections { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            electionEntityConfig.Configure(builder.Entity<Election>());
        }
    }
}
