using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class InsurancePolicyTypeDbEntityConfiguration : IEntityTypeConfiguration<InsurancePolicyTypeDbEntity>
{
    public void Configure(EntityTypeBuilder<InsurancePolicyTypeDbEntity> builder)
    {
        builder.ToTable("F008").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.DocumentId).HasColumnName("iddoc");
        builder.Property(prop => prop.DocumentName).HasColumnName("docname");

    }
}
