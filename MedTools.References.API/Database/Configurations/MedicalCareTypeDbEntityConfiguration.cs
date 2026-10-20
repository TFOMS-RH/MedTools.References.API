using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class MedicalCareTypeDbEntityConfiguration : IEntityTypeConfiguration<MedicalCareTypeDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalCareTypeDbEntity> builder)
    {
        builder.ToTable("v008").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("idvmp");

        builder.Property(prop => prop.MedicalCareName).HasColumnName("vmpname");
    }
}
