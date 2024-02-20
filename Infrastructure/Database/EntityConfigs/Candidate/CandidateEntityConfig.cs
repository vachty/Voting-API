using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Schema;

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

            builder.Property(x=>x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x=>x.LastName).HasMaxLength(50).IsRequired(true);
            builder.Property(x=>x.OpinionBrief).HasMaxLength(150).IsRequired(false);
            builder.Property(x => x.CandidateNumber).UseIdentityColumn(1,1);

            builder.Property(x => x.CandidateNumber).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
