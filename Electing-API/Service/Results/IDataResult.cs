namespace Electing_API.Service.Results
{
    /// <summary>
	/// The DataResult interface
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	public interface IDataResult<TData> : IResult
    {
        /// <summary>
        /// The data
        /// </summary>
        TData Data { get; set; }
    }
}
