using Electing_API.Service.Dtos.Election.Request;
using Swashbuckle.AspNetCore.Filters;

namespace Electing_API.Examples
{
    /// <summary>
    /// The lection request example
    /// </summary>
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
                UpVotes = new List<int>() {1,3,7},
                DownVotes = new List<int>() {4,5,2},
                IdentityCardId = "12345678",
                Name = "Name",
                LastName = "LastName"
            };
        }
    }
}
