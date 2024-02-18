using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.Candidate
{
    /// <summary>
    /// The Candidate repository
    /// </summary>
    public class CandidateRepository : BaseRepository<Domain.Dbo.Candidate>, ICandidateRepository
    {
        public CandidateRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
