using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.Entities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers.Options;

public sealed class MedicalCareOptionsProvider(
    MedicalReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetMedicalCareProlileOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<MedicalCareProfileDbEntity>()
            .AsNoTracking()
            .Select(x => new FilterOptionsDto(
                Label: x.ProfileName,
                Value: x.ProfileId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetBedProfileOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<BedProfileDbEntity>()
            .AsNoTracking()
            .Select(x => new FilterOptionsDto(
                Label: x.BedProfileName,
                Value: x.BedProfileId))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetCareConditionOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<CareConditionDbEntity>()
            .AsNoTracking()
            .Select(x => new FilterOptionsDto(
                Label: x.ConditionName,
                Value: x.ConditionId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetCareFormOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<CareFormDbEntity>()
            .AsNoTracking()
            .Where(x => x.CareFormName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.CareFormName!,
                Value: x.CareFormId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiagnosticMethodOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DiagnosticMethodDbEntity>()
            .AsNoTracking()
            .Where(x => x.DiagnosticMethodName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.DiagnosticMethodName!,
                Value: x.DiagnosticMethodId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetHighTechCareMethodOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<HighTechCareMethodDbEntity>()
            .Where(x => x.HighTechCareMethodId != null &&
                (x.HighTechCareMethodId.Contains(searchString) ||
                x.HighTechCareMethodName.Contains(searchString)))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.HighTechCareMethodId!} : {x.HighTechCareMethodName}",
                Value: x.HighTechCareMethodId!))
            .Distinct()
            .OrderBy(x => x.Value)
            .Take(30)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetHighTechCareTypeOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<HighTechCareTypeDbEntity>()
            .AsNoTracking()
            .Where(x => x.HighTechCareTypeId != null &&
                x.HighTechCareTypeId.Contains(searchString))
            .Select(x => new FilterOptionsDto(
                Label: x.HighTechCareTypeId!,
                Value: x.HighTechCareTypeId!))
            .Distinct()
            .OrderBy(x => x.Value)
            .Take(30)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetHospitalizationOutcomeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<HospitalizationOutcomeDbEntity>()
            .Join(
                dbContext.Set<CareConditionDbEntity>(),
                outcome => outcome.CareConditionId,
                condition => condition.Uid,
                (outcome, condition) => new FilterOptionsDto(
                    Label: $"{outcome.HospitalizationOutcomeName} ({condition.ConditionName})",
                    Value: outcome.HospitalizationOutcomeId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetMedicalCareTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<MedicalCareTypeDbEntity>()
            .AsNoTracking()
            .Select(x => new FilterOptionsDto(
                Label: x.MedicalCareName,
                Value: x.Uid.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetPhysicianSpecialtyOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<PhysicianSpecialtyDbEntity>()
            .AsNoTracking()
            .Select(x => new FilterOptionsDto(
                Label: x.SpecialityPostname == null || x.SpecialityPostname == string.Empty
                    ? x.SpecialityName
                    : $"{x.SpecialityName}" + " " + $"({x.SpecialityPostname})",
                Value: x.SpecialityId))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetReferralReasonOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ReferralReasonDbEntity>()
            .AsNoTracking()
            .Where(x => x.ReferralReasonName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ReferralReasonName!,
                Value: x.ReferralReasonId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetScreeningResultOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ScreeningResultDbEntity>()
            .AsNoTracking()
            .Where(x => x.ScreeningResultName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ScreeningResultName!,
                Value: x.ScreeningResultId))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

}