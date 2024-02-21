namespace Voting_API.Service.Dtos.Candidate.Response
{
    /// <summary>
    /// The Candidate list response dto
    /// </summary>
    public class CandidateListResponseDto : BaseResponseDto
    {
        /// <summary>
        /// The list of the candidates
        /// </summary>
        public IList<CandidateResponseDto> Candidates { get; set; } = new List<CandidateResponseDto>();
    }
}
