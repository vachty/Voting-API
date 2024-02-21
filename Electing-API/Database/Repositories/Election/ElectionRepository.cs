using Microsoft.EntityFrameworkCore;

namespace Electing_API.Database.Repositories.Election
{
    /// <summary>
    /// The Election repository
    /// </summary>
    public class ElectionRepository : BaseRepository<Domain.Dbo.Election>, IElectionRepository
    {
        public ElectionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <inheritdoc/>
        public async Task<Domain.Dbo.Election?> GetElectionByIdentityCardId(string identityCardId)
        {
            return await Entities.FirstOrDefaultAsync(x => x.IdentityCardId == identityCardId);
        }
    }
}
