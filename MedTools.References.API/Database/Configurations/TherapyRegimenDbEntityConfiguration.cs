using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class TherapyRegimenDbEntityConfiguration : IEntityTypeConfiguration<TherapyRegimenDbEntity>
{
    public void Configure(EntityTypeBuilder<TherapyRegimenDbEntity> builder)
    {
        builder.ToTable("V024").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.TherapyRegimenId).HasColumnName("iddkk");
        builder.Property(prop => prop.TherapyRegimenName).HasColumnName("dkkname").IsRequired(false);
    }
}
