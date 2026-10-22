using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace MedTools.References.API.Database;

public abstract class AppDbContext(
    DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

public sealed class MedicalReferenceDbContext(
    DbContextOptions<MedicalReferenceDbContext> options) : AppDbContext(options);

public sealed class MedicalInvoiceDbContext(
    DbContextOptions<MedicalInvoiceDbContext> options) : AppDbContext(options);
