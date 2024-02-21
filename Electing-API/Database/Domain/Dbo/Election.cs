namespace Electing_API.Database.Domain.Dbo
{
    /// <summary>
    /// The Election
    /// </summary>
    public class Election : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityCardId { get; set; }
        public string UpVotes { get; set; }
        public string DownVotes { get; set; }
    }
}
