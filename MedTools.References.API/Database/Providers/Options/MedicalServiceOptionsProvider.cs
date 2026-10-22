using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.DbEntities;
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
            .Where(x => x.DrugIdentifierId != null
                && x.DrugIdentifierName != null
                && (x.DrugIdentifierName.Contains(searchString) || x.DrugIdentifierId.StartsWith(searchString)))
            .Select(x => new FilterOptionsDto(
                Label: x.DrugIdentifierName!,
                Value: x.DrugIdentifierId!))
            .Distinct()
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDrugTherapyCycleOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DrugTherapyCycleDbEntity>()
            .Where(x => x.DrugTherapyCycleName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.DrugTherapyCycleName!,
                Value: x.DrugTherapyCycleId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDrugTherapyLineOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DrugTherapyLineDbEntity>()
            .Where(x => x.DrugTherapyLineName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.DrugTherapyLineName!,
                Value: x.DrugTherapyLineId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetMedicalServiceOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<MedicalServiceDbEntity>()
            .Where(x => x.ServiceName != null
                && (x.ServiceName.Contains(searchString) || x.ServiceCode.Contains(searchString)))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.ServiceCode} — {x.ServiceName}",
                Value: x.ServiceId.ToString()))
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetOncologyServiceTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<OncologyServiceTypeDbEntity>()
            .Where(x => x.ServiceName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ServiceName!,
                Value: x.ServiceId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetProvidedServiceOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ProvidedServiceDbEntity>()
            .Where(x => x.ProvidedServiceId != null
                && x.ProvidedServiceName != null
                && (x.ProvidedServiceId.Contains(searchString) || x.ProvidedServiceName.Contains(searchString)))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.ProvidedServiceId!} — {x.ProvidedServiceName!}",
                Value: x.ProvidedServiceId!))
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetRadioTherapyTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<RadioTherapyTypeDbEntity>()
            .Where(x => x.RadioTherapyTypeName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.RadioTherapyTypeName!,
                Value: x.RadioTherapyTypeId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetReferralTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ReferralTypeDbEntity>()
            .Where(x => x.ReferralName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ReferralName!,
                Value: x.ReferralId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetSurgicalTreatmentTypeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<SurgicalTreatmentTypeDbEntity>()
            .Where(x => x.SurgicalTreatmentTypeName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.SurgicalTreatmentTypeName!,
                Value: x.SurgicalTreatmentTypeId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetTherapyRegimenOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<TherapyRegimenDbEntity>()
            .Where(x => x.TherapyRegimenId.Contains(searchString))
            .Select(x => new FilterOptionsDto(
                Label: x.TherapyRegimenName!,
                Value: x.TherapyRegimenId))
            .Distinct()
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
