using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.Entities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers.Options;

public sealed class DocumentOptionsProvider(
    MedicalReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetInsurancePolicyTypeOptionsAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Set<InsurancePolicyTypeDbEntity>()
            .AsNoTracking()
            .Select(x => new FilterOptionsDto(
                Label: x.DocumentName,
                Value: x.DocumentId))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }
}
