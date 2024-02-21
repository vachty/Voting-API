namespace Voting_API.Service.Results
{
    /// <summary>
	/// The DataResult interface
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	public interface IDataResult<TData> : IResult
    {
        /// <summary>
        /// The Data
        /// </summary>
        TData Data { get; set; }
    }
}
