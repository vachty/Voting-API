using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Results;

namespace Voting_API.Controllers
{
    /// <summary>
	/// The Base Controller
	/// </summary>
	[ApiController]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorDto), 500)]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Creates instance of Controller with injected mediator
        /// </summary>
        /// <param name="mediator"></param>
        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        /// <summary>
        /// The Mediator
        /// </summary>
        protected IMediator Mediator { get; }

        /// <summary>
        /// The response of endpoints
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiDataResult"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected IActionResult ApiResponse<T>(IApiResult<T> apiDataResult) where T : BaseResponseDto
        {
            if (apiDataResult == null)
                throw new ArgumentNullException(nameof(apiDataResult));

            if (!apiDataResult.HasErrors)
            {
                return Ok(apiDataResult.Data);
            }

            return Problem(apiDataResult.GetErrorMessage(), null, Int32.Parse(apiDataResult.ErrorCode));
        }
    }
}
