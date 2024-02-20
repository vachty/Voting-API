namespace Domain.Dbo
{
    /// <summary>
    /// The Election
    /// </summary>
    public class Election : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentityCardId { get; set; }
    }
}
