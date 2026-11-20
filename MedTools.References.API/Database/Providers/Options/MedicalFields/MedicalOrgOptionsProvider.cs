using MedTools.References.API.Common.Constants;
using MedTools.References.API.Common.Models.Responces;
using MedTools.References.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedTools.References.API.Database.Providers.Options.MedicalFields;

public sealed class MedicalOrgOptionsProvider(
    MedicalReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetMedicalOrgOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<MedicalOrganizationDbEntity>()
            .AsNoTracking()
            .Where(x => x.Code != null &&
                x.Name != null &&
                x.Code.StartsWith(searchString))
            .Select(x => new { x.Code, x.Name })
            .Distinct()
            .OrderBy(x => x.Code)
            .ThenBy(x => x.Name)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.Code!} : {x.Name!}",
                Value: x.Code!))
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
            .Select(x => new { x.Code, x.Name })
            .Distinct()
            .OrderBy(x => x.Code)
            .ThenBy(x => x.Name)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.Code} : {x.Name}",
                Value: x.Code))
            .ToListAsync(cancellationToken);
    }

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




}
