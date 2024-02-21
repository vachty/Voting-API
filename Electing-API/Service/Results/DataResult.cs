namespace Electing_API.Service.Results
{
    /// <summary>
    /// The DataResult
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class DataResult<TData> : Result, IDataResult<TData>
    {
        /// <inheritdoc/>
        public TData Data { get; set; }
    }
}
