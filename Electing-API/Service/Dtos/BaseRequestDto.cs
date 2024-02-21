namespace Electing_API.Service.Dtos
{
    /// <summary>
	/// The Base class for the Request data transfer objects
	/// </summary>
	/// <typeparam name="TResponse"></typeparam>
	public abstract class BaseRequestDto<TResponse> : IBaseRequestDto<TResponse>
        where TResponse : IBaseResponseDto
    {
        /// <summary>
        /// The Id of the request
        /// </summary>
        Guid RequestId { get; set; }
    }
}
