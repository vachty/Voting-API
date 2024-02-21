namespace Electing_API.Service.Dtos
{
    /// <summary>
	/// The error dto
	/// </summary>
	public class ErrorDto
    {
        /// <summary>
        /// The error code
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// The reason of the error
        /// </summary>
        public string Reason { get; set; }
    }
}
