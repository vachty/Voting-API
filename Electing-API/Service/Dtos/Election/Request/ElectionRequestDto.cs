using Electing_API.Service.Dtos;
using Electing_API.Service.Dtos.Election.Response;

namespace Electing_API.Service.Dtos.Election.Request
{
    public class ElectionRequestDto : BaseRequestDto<ElectionResponseDto>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityCardId { get; set; }
        public List<int> CandidateNumbers { get; set; } = new List<int>();
    }
}