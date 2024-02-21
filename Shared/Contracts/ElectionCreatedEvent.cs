namespace Shared.Contracts
{
    /// <summary>
    /// The event when the Election is created
    /// </summary>
    public record ElectionCreatedEvent
    {
        /// <summary>
        /// The ID of the election
        /// </summary>
        public Guid ElectionId { get; set; }

        /// <summary>
        /// The up votes
        /// </summary>
        public string UpVotes {  get; set; }

        /// <summary>
        /// The down votes
        /// </summary>
        public string DownVotes { get; set; }
    }
}