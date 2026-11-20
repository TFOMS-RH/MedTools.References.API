using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.Entities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers.Options;

public sealed class PaymentOptionsProvider(
    MedicalReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetClinicalGroupOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ClinicalGroupDbEntity>()
            .AsNoTracking()
            .Where(x => x.ClinicalGroupName != null
                && x.ClinicalGroupId.Contains(searchString))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.ClinicalGroupId} — {x.ClinicalGroupName!}",
                Value: x.ClinicalGroupId))
            .Distinct()
            .OrderBy(x => x.Value)
            .Take(30)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetComplexityCoefficientOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ComplexityCoefficientDbEntity>()
            .AsNoTracking()
            .Where(x => x.ComplexityCoefficientName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ComplexityCoefficientName!,
                Value: x.ComplexityCoefficientId))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetControlTypeCodeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ControlTypeCodeDbEntity>()
            .AsNoTracking()
            .Where(x => x.ControlTypeCodeName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ControlTypeCodeName!,
                Value: x.ControlTypeCodeId))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetPaymentMethodOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<PaymentMethodDbEntity>()
            .AsNoTracking()
            .Select(x => new FilterOptionsDto(
                Label: x.PaymentMethodName,
                Value: x.Uid.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetRefusalReasonCodeOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<RefusalReasonCodeDbEntity>()
            .AsNoTracking()
            .Where(x => x.RefusalReasonCodeName.Contains(searchString)
                || x.RefusalReasonCodeId.ToString().StartsWith(searchString))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.RefusalReasonCodeId} : основание {x.RefusalReasonCodeName}",
                Value: x.RefusalReasonCodeId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .Take(30)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetInterruptedCasePaymentReasonOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<InterruptedCasePaymentReasonDbEntity>()
            .AsNoTracking()
            .Where(x => x.InterruptedCasePaymentReasonName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.InterruptedCasePaymentReasonName,
                Value: x.InterruptedCasePaymentReasonId))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }
}
