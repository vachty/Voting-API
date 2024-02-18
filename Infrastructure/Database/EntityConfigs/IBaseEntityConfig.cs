using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigs
{
    /// <summary>
	/// The Base entity configuration
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>, IBaseEntityConfig<TEntity>
        where TEntity : class, IBaseEntity
    {
        /// <summary>
        /// Configures the entity properties
        /// </summary>
        /// <param name="builder"></param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();
            builder.Property(p => p.CreationAuthor).HasMaxLength(50).IsRequired();
            builder.Property(p => p.UpdateDate).IsRequired();
            builder.Property(p => p.UpdateAuthor).HasMaxLength(50).IsRequired();
        }
    }
}
