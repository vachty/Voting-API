using MediatR;
using Voting_API.Service.Dtos;
using Voting_API.Service.Results;

namespace Voting_API.Service.Handlers
{
    /// <summary>
	/// The Base handler interface
	/// </summary>
	/// <typeparam name="TRequest"></typeparam>
	/// <typeparam name="TResponse"></typeparam>
	public interface IBaseHandler<in TRequest, TResponse> : IRequestHandler<TRequest, IApiResult<TResponse>>
        where TResponse : IBaseResponseDto
        where TRequest : IBaseRequestDto<TResponse>
    {
    }
}