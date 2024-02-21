using Service.Dtos.Election.Response;

namespace Service.Dtos.Election.Request
{
    public class ElectionRequestDto : BaseRequestDto<ElectionResponseDto>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityCardId { get; set; }
        public List<int> CandidateNumbers { get; set; } = new List<int>();
    }
}