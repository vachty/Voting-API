namespace Voting_API.Service.Results
{
    /// <summary>
    /// The DataResult
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class DataResult<TData> : Result, IDataResult<TData>
    {
        public TData Data { get; set; }
    }
}
