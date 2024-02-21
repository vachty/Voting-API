using Electing_API.Service.Results;
using MediatR;

namespace Electing_API.Service.Dtos
{
    /// <summary>
    /// The BaseRequestDto interface
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IBaseRequestDto<TResponse> : IRequest<IApiResult<TResponse>>
        where TResponse : IBaseResponseDto
    {
    }
}