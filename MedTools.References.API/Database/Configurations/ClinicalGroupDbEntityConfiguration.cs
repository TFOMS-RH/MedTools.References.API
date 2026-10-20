using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class ClinicalGroupDbEntityConfiguration : IEntityTypeConfiguration<ClinicalGroupDbEntity>
{
    public void Configure(EntityTypeBuilder<ClinicalGroupDbEntity> builder)
    {
        builder.ToTable("V023").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.ClinicalGroupId).HasColumnName("k_ksg");
        builder.Property(prop => prop.ClinicalGroupName).HasColumnName("n_ksg").IsRequired(false);
    }
}
