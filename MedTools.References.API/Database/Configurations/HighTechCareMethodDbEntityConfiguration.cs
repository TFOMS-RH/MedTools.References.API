using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class HighTechCareMethodDbEntityConfiguration : IEntityTypeConfiguration<HighTechCareMethodDbEntity>
{
    public void Configure(EntityTypeBuilder<HighTechCareMethodDbEntity> builder)
    {
        builder.ToTable("v019").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.HighTechCareMethodId).HasColumnName("IDHM").IsRequired(false);
        builder.Property(prop => prop.HighTechCareMethodName).HasColumnName("HMNAME");

    }
}
