using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.Entities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers.Options.MedicalFields;

public sealed class DocumentOptionsProvider(
    MedicalReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetInsurancePolicyTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<InsurancePolicyTypeDbEntity>()
            .AsNoTracking()
            .Select(x => new { x.DocumentId, x.DocumentName })
            .Distinct()
            .OrderBy(x => x.DocumentId)
            .ThenBy(x => x.DocumentName)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.DocumentId} : {x.DocumentName}",
                Value: x.DocumentId))
            .ToListAsync(cancellationToken);
    }
}
