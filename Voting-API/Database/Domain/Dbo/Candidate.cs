using Voting_API.Database.Domain;

namespace Voting_API.Database.Domain.Dbo
{
    /// <summary>
    /// The entity representing the candidate
    /// </summary>
    public class Candidate : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string OpinionBrief { get; set; }
        public int CandidateNumber { get; set; }
        public int Votes { get; set; }
    }
}
