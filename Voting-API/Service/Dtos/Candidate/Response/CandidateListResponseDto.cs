namespace Voting_API.Service.Dtos.Candidate.Response
{
    public class CandidateListResponseDto : BaseResponseDto
    {
        public IList<CandidateResponseDto> Candidates { get; set; } = new List<CandidateResponseDto>();
    }
}
