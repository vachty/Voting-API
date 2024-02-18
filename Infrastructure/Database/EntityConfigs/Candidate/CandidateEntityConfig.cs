﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigs.Candidate
{
    /// <summary>
    /// The entity configuration for candidate
    /// </summary>
    public class CandidateEntityConfig : BaseEntityConfig<Domain.Dbo.Candidate>, ICandidateEntityConfig
    {
        /// <inheritdoc/>
        public override void Configure(EntityTypeBuilder<Domain.Dbo.Candidate> builder)
        {
            base.Configure(builder);

            builder.Property(x=>x.Name).IsRequired(true);
            builder.Property(x=>x.LastName).IsRequired(true);
            builder.Property(x=>x.OpinionBrief).IsRequired(false);
        }
    }
}