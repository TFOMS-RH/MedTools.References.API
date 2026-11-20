using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedTools.References.API.Database.Entities;

namespace MedTools.References.API.Database.Configurations;

public sealed class MedicalOrganizationDbEntityConfiguration : IEntityTypeConfiguration<MedicalOrganizationDbEntity>
{
    public void Configure(EntityTypeBuilder<MedicalOrganizationDbEntity> builder)
    {
        builder.ToTable("F003").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.Code).HasColumnName("MCOD").IsRequired(false);
        builder.Property(prop => prop.Name).HasColumnName("NAM_MOK").IsRequired(false);
    }
}