using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Common.Constants;
using MedTools.References.API.Database.Entities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers.Options.MedicalFields;

public sealed class MedicalCareOptionsProvider(
    MedicalReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetMedicalCareProlileOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<MedicalCareProfileDbEntity>()
            .AsNoTracking()
            .Select(x => new { x.ProfileId, x.ProfileName })
            .Distinct()
            .OrderBy(x => x.ProfileId)
            .ThenBy(x => x.ProfileName)
            .Select(x => new FilterOptionsDto(
                Label: x.ProfileName,
                Value: x.ProfileId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetBedProfileOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<BedProfileDbEntity>()
            .AsNoTracking()
            .Select(x => new { x.BedProfileId, x.BedProfileName })
            .Distinct()
            .OrderBy(x => x.BedProfileId)
            .ThenBy(x => x.BedProfileName)
            .Select(x => new FilterOptionsDto(
                Label: x.BedProfileName,
                Value: x.BedProfileId))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetCareConditionOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<CareConditionDbEntity>()
            .AsNoTracking()
            .Select(x => new { x.ConditionId, x.ConditionName })
            .Distinct()
            .OrderBy(x => x.ConditionId)
            .ThenBy(x => x.ConditionName)
            .Select(x => new FilterOptionsDto(
                Label: x.ConditionName,
                Value: x.ConditionId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetCareFormOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<CareFormDbEntity>()
            .AsNoTracking()
            .Where(x => x.CareFormName != null)
            .Select(x => new { x.CareFormId, x.CareFormName })
            .Distinct()
            .OrderBy(x => x.CareFormId)
            .ThenBy(x => x.CareFormName)
            .Select(x => new FilterOptionsDto(
                Label: x.CareFormName!,
                Value: x.CareFormId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiagnosticMethodOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DiagnosticMethodDbEntity>()
            .AsNoTracking()
            .Where(x => x.DiagnosticMethodName != null)
            .Select(x => new { x.DiagnosticMethodId, x.DiagnosticMethodName })
            .Distinct()
            .OrderBy(x => x.DiagnosticMethodId)
            .ThenBy(x => x.DiagnosticMethodName)
            .Select(x => new FilterOptionsDto(
                Label: x.DiagnosticMethodName!,
                Value: x.DiagnosticMethodId.ToString()))
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
            .Select(x => new { x.HighTechCareMethodId, x.HighTechCareMethodName })
            .Distinct()
            .OrderBy(x => x.HighTechCareMethodId)
            .ThenBy(x => x.HighTechCareMethodName)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.HighTechCareMethodId!} : {x.HighTechCareMethodName}",
                Value: x.HighTechCareMethodId!))
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
            .Select(x => new { x.HighTechCareTypeId })
            .Distinct()
            .OrderBy(x => x.HighTechCareTypeId)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: x.HighTechCareTypeId!,
                Value: x.HighTechCareTypeId!))
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
                (outcome, condition) => new
                {
                    outcome.HospitalizationOutcomeName,
                    outcome.HospitalizationOutcomeId,
                    condition.ConditionName
                })
            .Distinct()
            .OrderBy(x => x.HospitalizationOutcomeId)
            .ThenBy(x => x.HospitalizationOutcomeName)
            .ThenBy(x => x.ConditionName)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.HospitalizationOutcomeName} ({x.ConditionName})",
                Value: x.HospitalizationOutcomeId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetMedicalCareTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<MedicalCareTypeDbEntity>()
            .AsNoTracking()
            .Distinct()
            .OrderBy(x => x.Uid)
            .ThenBy(x => x.MedicalCareName)
            .Select(x => new FilterOptionsDto(
                Label: x.MedicalCareName,
                Value: x.Uid.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetPhysicianSpecialtyOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<PhysicianSpecialtyDbEntity>()
            .AsNoTracking()
            .Select(x => new
            {
                x.SpecialityPostname,
                x.SpecialityName,
                x.SpecialityId
            })
            .Distinct()
            .OrderBy(x => x.SpecialityId)
            .ThenBy(x => x.SpecialityName)
            .ThenBy(x => x.SpecialityPostname)
            .Select(x => new FilterOptionsDto(
                Label: x.SpecialityPostname == null || x.SpecialityPostname == string.Empty
                    ? x.SpecialityName
                    : $"{x.SpecialityName}" + " " + $"({x.SpecialityPostname})",
                Value: x.SpecialityId))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetReferralReasonOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ReferralReasonDbEntity>()
            .AsNoTracking()
            .Where(x => x.ReferralReasonName != null)
            .Select(x => new { x.ReferralReasonId, x.ReferralReasonName })
            .Distinct()
            .OrderBy(x => x.ReferralReasonId)
            .ThenBy(x => x.ReferralReasonName)
            .Select(x => new FilterOptionsDto(
                Label: x.ReferralReasonName!,
                Value: x.ReferralReasonId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetScreeningResultOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ScreeningResultDbEntity>()
            .AsNoTracking()
            .Where(x => x.ScreeningResultName != null)
            .Select(x => new { x.ScreeningResultId, x.ScreeningResultName })
            .Distinct()
            .OrderBy(x => x.ScreeningResultId)
            .ThenBy(x => x.ScreeningResultName)
            .Select(x => new FilterOptionsDto(
                Label: x.ScreeningResultName!,
                Value: x.ScreeningResultId))
            .ToListAsync(cancellationToken);
    }

}