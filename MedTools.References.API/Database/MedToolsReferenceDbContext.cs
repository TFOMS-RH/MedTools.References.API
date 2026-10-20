using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace MedTools.References.API.Database;

public class MedToolsReferenceDbContext(
    DbContextOptions<MedToolsReferenceDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
