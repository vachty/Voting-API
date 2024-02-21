using Electing_API.Service.Dtos;
using Electing_API.Service.Results;

namespace Electing_API.Service.Handlers
{
    /// <summary>
	/// The BaseHandler 
	/// </summary>
	/// <typeparam name="TRequest"></typeparam>
	/// <typeparam name="TResponse"></typeparam>
	public abstract class BaseHandler<TRequest, TResponse> : IBaseHandler<TRequest, TResponse>
        where TRequest : IBaseRequestDto<TResponse>
        where TResponse : IBaseResponseDto
    {
        /// <summary>
        /// Handles the request / response, called by mediator
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<IApiResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
