using Voting_API.Database.Domain.Dbo;
using Voting_API.Database.EntityConfigs.Candidate;
using Microsoft.EntityFrameworkCore;

namespace Voting_API.Database
{
    /// <summary>
    /// The voting api microservice db context
    /// </summary>
    public class VotingApiDbContext : DbContext, IVotingApiDbContext
    {
        /// <summary>
        /// The candidate entity config
        /// </summary>
        private readonly ICandidateEntityConfig candidateEntityConfig;

        /// <summary>
        /// Creates instance of the database context
        /// </summary>
        /// <param name="candidateEntityConfig"></param>
        /// <param name="options"></param>
        public VotingApiDbContext(
            ICandidateEntityConfig candidateEntityConfig,
            DbContextOptions<VotingApiDbContext> options) : base(options)
        {
            this.candidateEntityConfig = candidateEntityConfig;
        }

        /// <inheritdoc/>
        public DbSet<Candidate> Candidates { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            candidateEntityConfig.Configure(builder.Entity<Candidate>());
        }
    }
}