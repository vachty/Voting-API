namespace Electing_API.Service.Results
{
    /// <summary>
	/// The API result
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	public class ApiResult<TData> : DataResult<TData>, IApiResult<TData>
    {
        ///<inheritdoc/>
        public string ErrorCode { get; set; }
    }
}
