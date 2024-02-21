using Electing_API.Service.Dtos;
using Electing_API.Service.Results;
using MediatR;

namespace Electing_API.Service.Handlers
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