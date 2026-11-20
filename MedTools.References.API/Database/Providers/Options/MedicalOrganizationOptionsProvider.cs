using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.Entities;
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
            .AsNoTracking()
            .Select(x => new FilterOptionsDto(
                Label: x.VisitPlaceName,
                Value: x.VisitPlaceId))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetVisitPurposeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<VisitPurposeDbEntity>()
            .AsNoTracking()
            .Where(x => x.VisitPurposeName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.VisitPurposeName!,
                Value: x.VisitPurposeId))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetMedicalOrgOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<MedicalOrganizationDbEntity>()
            .AsNoTracking()
            .Where(
                x => x.Code != null &&
                x.Name != null &&
                x.Code.StartsWith(searchString))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.Code!} : {x.Name!}",
                Value: x.Code!))
            .Distinct()
            .OrderBy(x => x.Value)
            .Take(15)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetInsuranceOrgOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<InsuranceDbEntity>()
            .AsNoTracking()
            .Where(x => x.Code.StartsWith(searchString))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.Code} : {x.Name}",
                Value: x.Code))
            .Distinct()
            .OrderBy(x => x.Value)
            .Take(15)
            .ToListAsync(cancellationToken);
    }
}
