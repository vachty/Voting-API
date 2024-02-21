namespace Voting_API.Database.Domain
{
    /// <summary>
    /// The base entity interface
    /// </summary>
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        string CreationAuthor { get; set; }

        DateTime CreationDate { get; set; }

        string UpdateAuthor { get; set; }

        DateTime UpdateDate { get; set; }
    }
}
