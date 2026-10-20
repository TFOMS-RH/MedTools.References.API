using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class BedProfileDbEntityConfiguration : IEntityTypeConfiguration<BedProfileDbEntity>
{
    public void Configure(EntityTypeBuilder<BedProfileDbEntity> builder)
    {
        builder.ToTable("V020").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.BedProfileId).HasColumnName("idk_pr");
        builder.Property(prop => prop.BedProfileName).HasColumnName("k_prname");
    }
}
