using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class CareFormDbEntityConfiguration : IEntityTypeConfiguration<CareFormDbEntity>
{
    public void Configure(EntityTypeBuilder<CareFormDbEntity> builder)
    {
        builder.ToTable("V014").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.CareFormId).HasColumnName("IDFRMMP");
        builder.Property(prop => prop.CareFormName).HasColumnName("FRMMPNAME").IsRequired(false);
    }
}
