using Domain.Dbo;
using Infrastructure.Database.EntityConfigs.Candidate;
using Infrastructure.Database.EntityConfigs.Election;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class VotingApiDbContext : DbContext, IVotingApiDbContext
    {
        /// <summary>
        /// The candidate entity config
        /// </summary>
        private readonly ICandidateEntityConfig candidateEntityConfig;

        /// <summary>
        /// The election entity config
        /// </summary>
        private readonly IElectionEntityConfig electionEntityConfig;

        /// <summary>
        /// Creates instance of the database context
        /// </summary>
        /// <param name="candidateEntityConfig"></param>
        /// <param name="electionEntityConfig"></param>
        /// <param name="options"></param>
        public VotingApiDbContext(
            ICandidateEntityConfig candidateEntityConfig,
            IElectionEntityConfig electionEntityConfig,
            DbContextOptions<VotingApiDbContext> options) : base(options)
        {
            this.candidateEntityConfig = candidateEntityConfig;
            this.electionEntityConfig = electionEntityConfig;
        }

        /// <inheritdoc/>
        public DbSet<Candidate> Candidates { get; set; }

        /// <inheritdoc/>
        public DbSet<Election> Elections { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            candidateEntityConfig.Configure(builder.Entity<Candidate>());
            electionEntityConfig.Configure(builder.Entity<Election>());
        }
    }
}
