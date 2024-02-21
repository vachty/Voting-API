using Electing_API.Service.Dtos.Election.Response;

namespace Electing_API.Service.Dtos.Election.Request
{
    /// <summary>
    /// The Election create request dto
    /// </summary>
    public class ElectionRequestDto : BaseRequestDto<ElectionResponseDto>
    {
        /// <summary>
        /// The name of the person who made the vote
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The last name of the person who made the vote
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Number of the persons identity card
        /// </summary>
        public string IdentityCardId { get; set; }

        /// <summary>
        /// Candidate numbers which will be upvoted
        /// </summary>
        public List<int> UpVotes { get; set; } = new List<int>();

        /// <summary>
        /// Candidate numbers which will be downvoted
        /// </summary>
        public List<int> DownVotes { get; set; } = new List<int>();
    }
}