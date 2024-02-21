namespace Voting_API.Database.Repositories.Candidate
{
    /// <summary>
    /// The Candidate repository interface
    /// </summary>
    public interface ICandidateRepository : IBaseRepository <Domain.Dbo.Candidate>
    {
        /// <summary>
        /// Gets the candidates by their election numbers
        /// </summary>
        /// <param name="voteNumbers"></param>
        /// <returns></returns>
        Task<List<Domain.Dbo.Candidate>> GetCandidateByVoteNumbers(List<int> voteNumbers);
    }
}