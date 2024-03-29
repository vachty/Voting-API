﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Electing_API.Database.EntityConfigs.Election
{
    /// <summary>
    /// The election entity config
    /// </summary>
    public class ElectionEntityConfig : BaseEntityConfig<Domain.Dbo.Election>, IElectionEntityConfig
    {
        /// <inheritdoc/>
        public override void Configure(EntityTypeBuilder<Domain.Dbo.Election> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.IdentityCardId).HasMaxLength(20).IsRequired(true);
        }
    }
}
