using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations;

public sealed class InterruptedCasePaymentReasonDbEntityConfiguration : IEntityTypeConfiguration<InterruptedCasePaymentReasonDbEntity>
{
    public void Configure(EntityTypeBuilder<InterruptedCasePaymentReasonDbEntity> builder)
    {
        builder.ToTable("V042").HasKey(entity => entity.Uid);

        builder.Property(prop => prop.Uid).HasColumnName("uid");

        builder.Property(prop => prop.InterruptedCasePaymentReasonId).HasColumnName("ID_PR");
        builder.Property(prop => prop.InterruptedCasePaymentReasonName).HasColumnName("N_PR");
    }
}