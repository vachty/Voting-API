namespace Voting_API.Service.Dtos.Candidate.Response
{
    /// <summary>
    /// The Candidate response dto
    /// </summary>
    public class CandidateResponseDto : BaseResponseDto
    {
        /// <summary>
        /// The voting number of the candidate
        /// </summary>
        public int CandidateNumber { get; set; }

        /// <summary>
        /// The candidates name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The candidates last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The candidates opinions
        /// </summary>
        public string OpinionBrief { get; set; }

        /// <summary>
        /// Candidates number of votes
        /// </summary>
        public int Votes { get; set; }
    }
}
