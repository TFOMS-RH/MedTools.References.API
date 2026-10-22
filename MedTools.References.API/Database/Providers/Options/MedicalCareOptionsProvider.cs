using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.DbEntities;
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
            .Select(x => new FilterOptionsDto(
                Label: x.ProfileName,
                Value: x.ProfileId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetBedProfileOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<BedProfileDbEntity>()
            .Select(x => new FilterOptionsDto(
                Label: x.BedProfileName,
                Value: x.BedProfileId))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetCareConditionOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<CareConditionDbEntity>()
            .Select(x => new FilterOptionsDto(
                Label: x.ConditionName,
                Value: x.ConditionId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetCareFormOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<CareFormDbEntity>()
            .Where(x => x.CareFormName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.CareFormName!,
                Value: x.CareFormId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiagnosticMethodOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DiagnosticMethodDbEntity>()
            .Where(x => x.DiagnosticMethodName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.DiagnosticMethodName!,
                Value: x.DiagnosticMethodId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetHighTechCareMethodOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<HighTechCareMethodDbEntity>()
            .Where(x => x.HighTechCareMethodId != null
                && x.HighTechCareMethodName.Contains(searchString))
            .Select(x => new FilterOptionsDto(
                Label: x.HighTechCareMethodName,
                Value: x.HighTechCareMethodId!))
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetHighTechCareTypeOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<HighTechCareTypeDbEntity>()
            .Where(x => x.HighTechCareTypeId != null
                && x.HighTechCareTypeName != null
                && x.HighTechCareTypeId.StartsWith(searchString))
            .Select(x => new FilterOptionsDto(
                Label: x.HighTechCareTypeName!,
                Value: x.HighTechCareTypeId!))
            .Distinct()
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);
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
         .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetMedicalCareTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<MedicalCareTypeDbEntity>()
            .Select(x => new FilterOptionsDto(
                Label: x.MedicalCareName,
                Value: x.Uid.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetPhysicianSpecialtyOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<PhysicianSpecialtyDbEntity>()
            .Select(x => new FilterOptionsDto(
                Label: x.SpecialityPostname == null || x.SpecialityPostname == string.Empty 
                    ? x.SpecialityName 
                    : $"{x.SpecialityName}" + " " + $"({x.SpecialityPostname})",
                Value: x.SpecialityId))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetReferralReasonOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ReferralReasonDbEntity>()
            .Where(x => x.ReferralReasonName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ReferralReasonName!,
                Value: x.ReferralReasonId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetScreeningResultOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ScreeningResultDbEntity>()
            .Where(x => x.ScreeningResultName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ScreeningResultName!,
                Value: x.ScreeningResultId))
            .ToListAsync(cancellationToken: cancellationToken);
    }

}