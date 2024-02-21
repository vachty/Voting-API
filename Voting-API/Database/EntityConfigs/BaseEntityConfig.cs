using Voting_API.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Voting_API.Database.EntityConfigs
{
    /// <summary>
	/// The Base Entity Configuration interface
	/// </summary>
	public interface IBaseEntityConfig<TEntity>
        where TEntity : class, IBaseEntity
    {
        /// <summary>
        /// Configures the entity/table
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TEntity> builder);
    }
}
