using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Common.Constants;
using MedTools.References.API.Database.Entities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers.Options.MedicalFields;

public sealed class MedicalServiceOptionsProvider(
    MedicalReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDrugIdentifierOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DrugIdentifierDbEntity>()
            .AsNoTracking()
            .Where(x => x.DrugIdentifierId != null &&
                x.DrugIdentifierId.Contains(searchString))
            .Select(x => new { x.DrugIdentifierId })
            .Distinct()
            .OrderBy(x => x.DrugIdentifierId)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: x.DrugIdentifierId!,
                Value: x.DrugIdentifierId!))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDrugTherapyCycleOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DrugTherapyCycleDbEntity>()
            .AsNoTracking()
            .Where(x => x.DrugTherapyCycleName != null)
            .Select(x => new { x.DrugTherapyCycleId, x.DrugTherapyCycleName })
            .Distinct()
            .OrderBy(x => x.DrugTherapyCycleId)
            .ThenBy(x => x.DrugTherapyCycleName)
            .Select(x => new FilterOptionsDto(
                Label: x.DrugTherapyCycleName!,
                Value: x.DrugTherapyCycleId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDrugTherapyLineOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DrugTherapyLineDbEntity>()
            .AsNoTracking()
            .Where(x => x.DrugTherapyLineName != null)
            .Select(x => new { x.DrugTherapyLineId, x.DrugTherapyLineName })
            .Distinct()
            .OrderBy(x => x.DrugTherapyLineId)
            .ThenBy(x => x.DrugTherapyLineName)
            .Select(x => new FilterOptionsDto(
                Label: x.DrugTherapyLineName!,
                Value: x.DrugTherapyLineId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetMedicalServiceOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<MedicalServiceDbEntity>()
            .AsNoTracking()
            .Where(x => x.ServiceName != null &&
                (x.ServiceName.Contains(searchString) ||
                x.ServiceCode.Contains(searchString)))
            .Select(x => new { x.ServiceCode, x.ServiceName })
            .Distinct()
            .OrderBy(x => x.ServiceCode)
            .ThenBy(x => x.ServiceName)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.ServiceCode} : {x.ServiceName}",
                Value: x.ServiceCode))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetOncologyServiceTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<OncologyServiceTypeDbEntity>()
            .AsNoTracking()
            .Where(x => x.ServiceName != null)
            .Select(x => new { x.ServiceId, x.ServiceName })
            .Distinct()
            .OrderBy(x => x.ServiceId)
            .ThenBy(x => x.ServiceName)
            .Select(x => new FilterOptionsDto(
                Label: x.ServiceName!,
                Value: x.ServiceId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetProvidedServiceOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ProvidedServiceDbEntity>()
            .AsNoTracking()
            .Where(x => x.ProvidedServiceId != null &&
                x.ProvidedServiceName != null &&
                (x.ProvidedServiceId.Contains(searchString) ||
                    x.ProvidedServiceName.Contains(searchString)))
            .Select(x => new { x.ProvidedServiceId, x.ProvidedServiceName })
            .Distinct()
            .OrderBy(x => x.ProvidedServiceId)
            .ThenBy(x => x.ProvidedServiceName)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.ProvidedServiceId!} : {x.ProvidedServiceName!}",
                Value: x.ProvidedServiceId!))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetRadioTherapyTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<RadioTherapyTypeDbEntity>()
            .AsNoTracking()
            .Where(x => x.RadioTherapyTypeName != null)
            .Select(x => new { x.RadioTherapyTypeId, x.RadioTherapyTypeName })
            .Distinct()
            .OrderBy(x => x.RadioTherapyTypeId)
            .ThenBy(x => x.RadioTherapyTypeName)
            .Select(x => new FilterOptionsDto(
                Label: x.RadioTherapyTypeName!,
                Value: x.RadioTherapyTypeId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetReferralTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ReferralTypeDbEntity>()
            .AsNoTracking()
            .Where(x => x.ReferralName != null)
            .Select(x => new { x.ReferralId, x.ReferralName })
            .Distinct()
            .OrderBy(x => x.ReferralId)
            .ThenBy(x => x.ReferralName)
            .Select(x => new FilterOptionsDto(
                Label: x.ReferralName!,
                Value: x.ReferralId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetSurgicalTreatmentTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<SurgicalTreatmentTypeDbEntity>()
            .AsNoTracking()
            .Where(x => x.SurgicalTreatmentTypeName != null)
            .Select(x => new { x.SurgicalTreatmentTypeId, x.SurgicalTreatmentTypeName })
            .Distinct()
            .OrderBy(x => x.SurgicalTreatmentTypeId)
            .ThenBy(x => x.SurgicalTreatmentTypeName)
            .Select(x => new FilterOptionsDto(
                Label: x.SurgicalTreatmentTypeName!,
                Value: x.SurgicalTreatmentTypeId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetTherapyRegimenOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<TherapyRegimenDbEntity>()
            .AsNoTracking()
            .Where(x => x.TherapyRegimenId.Contains(searchString))
            .Select(x => new { x.TherapyRegimenId })
            .Distinct()
            .OrderBy(x => x.TherapyRegimenId)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: x.TherapyRegimenId,
                Value: x.TherapyRegimenId))
            .ToListAsync(cancellationToken);
    }
}
