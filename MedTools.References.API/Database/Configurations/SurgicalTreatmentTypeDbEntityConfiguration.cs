using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class SurgicalTreatmentTypeDbEntityConfiguration : IEntityTypeConfiguration<SurgicalTreatmentTypeDbEntity>
{
    public void Configure(EntityTypeBuilder<SurgicalTreatmentTypeDbEntity> builder)
    {
        builder.ToTable("N014").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.SurgicalTreatmentTypeId).HasColumnName("ID_THir");
        builder.Property(prop => prop.SurgicalTreatmentTypeName).HasColumnName("THir_Name").IsRequired(false);
    }
}