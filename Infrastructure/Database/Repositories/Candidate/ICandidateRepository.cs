namespace Infrastructure.Database.Repositories.Candidate
{
    /// <summary>
    /// The Candidate repository interface
    /// </summary>
    public interface ICandidateRepository : IBaseRepository <Domain.Dbo.Candidate>
    {
        Task<List<Domain.Dbo.Candidate>> GetCandidateByVoteNumbers(List<int> voteNumbers);
    }
}
