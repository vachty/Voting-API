namespace Electing_API.Service.Results
{
    /// <summary>
	/// The API result
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	public class ApiResult<TData> : DataResult<TData>, IApiResult<TData>
    {
        public string ErrorCode { get; set; }
    }
}
