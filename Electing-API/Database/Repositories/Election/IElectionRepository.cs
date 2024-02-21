namespace Electing_API.Database.Repositories.Election
{
    /// <summary>
    /// The Election repository interface
    /// </summary>
    public interface IElectionRepository : IBaseRepository<Domain.Dbo.Election>
    {
        /// <summary>
        /// Gets the election by card id
        /// </summary>
        /// <param name="identityCardId"></param>
        /// <returns></returns>
        Task<Domain.Dbo.Election?> GetElectionByIdentityCardId(string identityCardId);
    }
}