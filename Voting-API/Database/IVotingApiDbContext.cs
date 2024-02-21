using Voting_API.Database.Domain.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Voting_API.Database
{
    /// <summary>
    /// The Voting API database context interface
    /// </summary>
    public interface IVotingApiDbContext
    {
        /// <summary>
        /// The Candidates
        /// </summary>
        DbSet<Candidate> Candidates { get; set; }
    }
}
