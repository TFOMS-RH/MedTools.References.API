using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class RefusalReasonCodeDbEntityConfiguration : IEntityTypeConfiguration<RefusalReasonCodeDbEntity>
{
    public void Configure(EntityTypeBuilder<RefusalReasonCodeDbEntity> builder)
    {
        builder.ToTable("F014").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.RefusalReasonCodeId).HasColumnName("Kod");
        builder.Property(prop => prop.RefusalReasonCodeName).HasColumnName("Osn").IsRequired(false);
    }
}