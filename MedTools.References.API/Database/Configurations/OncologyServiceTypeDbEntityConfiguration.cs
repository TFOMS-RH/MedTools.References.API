using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class OncologyServiceTypeDbEntityConfiguration : IEntityTypeConfiguration<OncologyServiceTypeDbEntity>
{
    public void Configure(EntityTypeBuilder<OncologyServiceTypeDbEntity> builder)
    {
        builder.ToTable("N013").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ServiceId).HasColumnName("ID_TLech");
        builder.Property(prop => prop.ServiceName).HasColumnName("TLech_Name").IsRequired(false);
    }
}
