using Microsoft.EntityFrameworkCore;

namespace Voting_API.Database.Repositories.Candidate
{
    /// <summary>
    /// The Candidate repository
    /// </summary>
    public class CandidateRepository : BaseRepository<Domain.Dbo.Candidate>, ICandidateRepository
    {
        /// <summary>
        /// Create instance of CandidateRepository
        /// </summary>
        /// <param name="dbContext"></param>
        public CandidateRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Gets the candidates by their candidate numbers
        /// </summary>
        /// <param name="voteNumbers"></param>
        /// <returns></returns>
        public async Task<List<Domain.Dbo.Candidate>> GetCandidateByVoteNumbers(List<int> voteNumbers)
        {
            var entities = await Entities.Where(x => voteNumbers.Contains(x.CandidateNumber)).ToListAsync();

            return entities;
        }
    }
}
