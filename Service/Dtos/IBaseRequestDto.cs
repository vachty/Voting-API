using MediatR;
using Service.Results;

namespace Service.Dtos
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
