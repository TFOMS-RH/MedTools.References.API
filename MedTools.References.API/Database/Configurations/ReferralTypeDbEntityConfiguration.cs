using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class ReferralTypeDbEntityConfiguration : IEntityTypeConfiguration<ReferralTypeDbEntity>
{
    public void Configure(EntityTypeBuilder<ReferralTypeDbEntity> builder)
    {
        builder.ToTable("V028").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ReferralId).HasColumnName("idvn");
        builder.Property(prop => prop.ReferralName).HasColumnName("n_vn").IsRequired(false);
    }
}