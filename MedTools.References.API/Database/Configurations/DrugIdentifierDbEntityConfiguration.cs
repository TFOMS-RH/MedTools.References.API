using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Configurations
{
    public sealed class DrugIdentifierDbEntityConfiguration : IEntityTypeConfiguration<DrugIdentifierDbEntity>
    {
        public void Configure(EntityTypeBuilder<DrugIdentifierDbEntity> builder)
        {
            builder.ToTable("N020").HasKey(entity => entity.Uid);

            builder.Property(prop => prop.Uid).HasColumnName("uid");

            builder.Property(prop => prop.DrugIdentifierId).HasColumnName("id_lekp").IsRequired(false);
            builder.Property(prop => prop.DrugIdentifierName).HasColumnName("mnn").IsRequired(false);
        }
    }
}