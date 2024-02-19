namespace Service.Dtos.Candidate.Response
{
    public class CandidateResponseDto : BaseResponseDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string OpinionBrief { get; set; }
        public int Votes {  get; set; }
    }
}
