using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Electing_API.Service.Dtos.Election.Request;
using Electing_API.Service.Dtos.Election.Response;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace Electing_API.Controllers.Election
{
    /// <summary>
    /// The Election Controller
    /// </summary>
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ElectionController : BaseController
    {
        /// <summary>
        /// Create instance of the ElectionController
        /// </summary>
        /// <param name="mediator"></param>
        public ElectionController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
		/// Gets the product by Id
		/// </summary>
		/// <param name="electionRequest"></param>
		/// <returns></returns>
		[HttpPost]
        [Route("Create")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ElectionResponseDto), (int)HttpStatusCode.OK)]
        [SwaggerRequestExample(typeof(ElectionResponseDto), typeof(ElectionRequestDto))]
        public async Task<IActionResult> Create([FromBody] ElectionRequestDto electionRequest)
        {
            return ApiResponse(await Mediator.Send(electionRequest));
        }
    }
}
