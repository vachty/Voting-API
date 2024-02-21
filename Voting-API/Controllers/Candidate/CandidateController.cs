using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Voting_API.Service.Dtos.Candidate.Request;
using Voting_API.Service.Dtos.Candidate.Response;
using Swashbuckle.AspNetCore.Filters;
using System.Net;
using Voting_API.Examples;

namespace Voting_API.Controllers.Candidate
{
    /// <summary>
    /// The Candidate controller
    /// </summary>
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CandidateController : BaseController
    {
        /// <summary>
        /// Create instance of CandidateController
        /// </summary>
        /// <param name="mediator"></param>
        public CandidateController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
		/// Gets the product by Id
		/// </summary>
		/// <param name="candidatesRequest"></param>
		/// <returns></returns>
		[HttpGet]
        [Route("SearchList")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(CandidateListResponseDto), (int)HttpStatusCode.OK)]
        [SwaggerRequestExample(typeof(CandidateListRequestDto), typeof(CandidateListRequestDtoExample))]
        public async Task<IActionResult> Search([FromBody] CandidateListRequestDto candidatesRequest)
        {
            return ApiResponse(await Mediator.Send(candidatesRequest));
        }
    }
}
