using Electing_API.Database.Domain.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Electing_API.Database
{
    /// <summary>
    /// The Election Db context interface
    /// </summary>
    public interface IElectionApiDbContext
    {
        /// <summary>
        /// The Elections
        /// </summary>
        DbSet<Election> Elections { get; set; }
    }
}
