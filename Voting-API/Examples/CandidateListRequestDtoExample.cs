using Voting_API.Service.Dtos.Candidate.Request;
using Swashbuckle.AspNetCore.Filters;

namespace Voting_API.Examples
{
    /// <summary>
    /// The Product Request Dto example
    /// </summary>
    public class CandidateListRequestDtoExample : IExamplesProvider<CandidateListRequestDto>
    {
        /// <summary>
        /// Get the examples
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public CandidateListRequestDto GetExamples()
        {
            return new CandidateListRequestDto()
            {
            };
        }
    }
}
