using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class MedicalCareProfileDbEntityConfiguration : IEntityTypeConfiguration<MedicalCareProfileDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalCareProfileDbEntity> builder)
    {
        builder.ToTable("V002").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ProfileId).HasColumnName("IDPR");
        builder.Property(prop => prop.ProfileName).HasColumnName("PRNAME");
    }
}