using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.DbEntities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers;

public sealed class DocumentReferenceDataProvider(
    MedToolsReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetInsurancePolicyTypesAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Set<InsurancePolicyTypeDbEntity>()
            .Select(x => new FilterOptionsDto(
                Label: x.DocumentName,
                Value: x.DocumentId))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
