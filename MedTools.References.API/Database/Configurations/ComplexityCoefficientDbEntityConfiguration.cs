using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class ComplexityCoefficientDbEntityConfiguration : IEntityTypeConfiguration<ComplexityCoefficientDbEntity>
{
    public void Configure(EntityTypeBuilder<ComplexityCoefficientDbEntity> builder)
    {
        builder.ToTable("Spr_KSLP").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ComplexityCoefficientId).HasColumnName("Nom");
        builder.Property(prop => prop.ComplexityCoefficientName).HasColumnName("Name").IsRequired(false);
    }
}