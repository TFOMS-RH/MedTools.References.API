using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.Entities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers.Options;

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
            .Where(x => x.DrugIdentifierId != null
                && x.DrugIdentifierName != null
                && (x.DrugIdentifierId.Contains(searchString)))
            .Select(x => new FilterOptionsDto(
                Label: x.DrugIdentifierId!,
                Value: x.DrugIdentifierId!))
            .Distinct()
            .OrderBy(x => x.Value)
            .Take(30)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDrugTherapyCycleOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DrugTherapyCycleDbEntity>()
            .AsNoTracking()
            .Where(x => x.DrugTherapyCycleName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.DrugTherapyCycleName!,
                Value: x.DrugTherapyCycleId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDrugTherapyLineOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DrugTherapyLineDbEntity>()
            .AsNoTracking()
            .Where(x => x.DrugTherapyLineName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.DrugTherapyLineName!,
                Value: x.DrugTherapyLineId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetMedicalServiceOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<MedicalServiceDbEntity>()
            .AsNoTracking()
            .Where(x => x.ServiceName != null
                && (x.ServiceName.Contains(searchString) || x.ServiceCode.Contains(searchString)))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.ServiceCode} — {x.ServiceName}",
                Value: x.ServiceId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .Take(30)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetOncologyServiceTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<OncologyServiceTypeDbEntity>()
            .AsNoTracking()
            .Where(x => x.ServiceName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ServiceName!,
                Value: x.ServiceId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetProvidedServiceOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ProvidedServiceDbEntity>()
            .AsNoTracking()
            .Where(x => x.ProvidedServiceId != null
                && x.ProvidedServiceName != null
                && (x.ProvidedServiceId.Contains(searchString) || x.ProvidedServiceName.Contains(searchString)))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.ProvidedServiceId!} — {x.ProvidedServiceName!}",
                Value: x.ProvidedServiceId!))
            .Distinct()
            .OrderBy(x => x.Value)
            .Take(30)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetRadioTherapyTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<RadioTherapyTypeDbEntity>()
            .AsNoTracking()
            .Where(x => x.RadioTherapyTypeName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.RadioTherapyTypeName!,
                Value: x.RadioTherapyTypeId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetReferralTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ReferralTypeDbEntity>()
            .AsNoTracking()
            .Where(x => x.ReferralName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ReferralName!,
                Value: x.ReferralId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetSurgicalTreatmentTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<SurgicalTreatmentTypeDbEntity>()
            .AsNoTracking()
            .Where(x => x.SurgicalTreatmentTypeName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.SurgicalTreatmentTypeName!,
                Value: x.SurgicalTreatmentTypeId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
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
            .Select(x => new FilterOptionsDto(
                Label: x.TherapyRegimenId,
                Value: x.TherapyRegimenId))
            .Distinct()
            .OrderBy(x => x.Value)
            .Take(30)
            .ToListAsync(cancellationToken);
    }
}
