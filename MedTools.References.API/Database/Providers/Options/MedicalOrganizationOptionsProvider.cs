using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.DbEntities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers.Options;

public sealed class MedicalOrganizationOptionsProvider(
    MedicalReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetVisitPlaceOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<VisitPlaceDbEntity>()
            .Select(x => new FilterOptionsDto(
                Label: x.VisitPlaceName,
                Value: x.VisitPlaceId))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetVisitPurposeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<VisitPurposeDbEntity>()
            .Where(x => x.VisitPurposeName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.VisitPurposeName!,
                Value: x.VisitPurposeId))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
