using Domain.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
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

        /// <summary>
        /// The Elections
        /// </summary>
        DbSet<Election> Elections { get; set; }
    }
}
