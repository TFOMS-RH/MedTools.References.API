using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class VisitPurposeDbEntityConfiguration : IEntityTypeConfiguration<VisitPurposeDbEntity>
{
    public void Configure(EntityTypeBuilder<VisitPurposeDbEntity> builder)
    {
        builder.ToTable("V025").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.VisitPurposeId).HasColumnName("idpc");
        builder.Property(prop => prop.VisitPurposeName).HasColumnName("n_pc");
    }
}