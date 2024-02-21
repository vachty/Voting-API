namespace Voting_API.Database.Domain
{
    /// <summary>
    /// The base entity
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        /// <summary>
        /// The ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The author of creation
        /// </summary>
        public string CreationAuthor { get; set; }

        /// <summary>
        /// The date when created
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// The author of update
        /// </summary>
        public string UpdateAuthor { get; set; }

        /// <summary>
        /// The update date
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
