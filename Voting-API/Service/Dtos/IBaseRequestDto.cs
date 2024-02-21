using MediatR;
using Voting_API.Service.Results;

namespace Voting_API.Service.Dtos
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
