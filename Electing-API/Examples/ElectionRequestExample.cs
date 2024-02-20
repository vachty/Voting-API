using Service.Dtos.Election.Request;
using Swashbuckle.AspNetCore.Filters;

namespace Electing_API.Examples
{
    public class ElectionRequestExample : IExamplesProvider<ElectionRequestDto>
    {
        /// <summary>
        /// Get the examples
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ElectionRequestDto GetExamples()
        {
            return new ElectionRequestDto()
            {
                CandidateNumbers = new List<int>() {1,2,3},
                IdentityCardId = "12345678",
                Name = "Name",
                LastName = "LastName"
            };
        }
    }
}
