using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database.DbEntities;
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
            .Where(x => x.ClinicalGroupName != null
                && x.ClinicalGroupId.Contains(searchString))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.ClinicalGroupId} — {x.ClinicalGroupName!}",
                Value: x.ClinicalGroupId))
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetComplexityCoefficientOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ComplexityCoefficientDbEntity>()
            .Where(x => x.ComplexityCoefficientName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ComplexityCoefficientName!,
                Value: x.ComplexityCoefficientId))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetControlTypeCodeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ControlTypeCodeDbEntity>()
            .Where(x => x.ControlTypeCodeName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.ControlTypeCodeName!,
                Value: x.ControlTypeCodeId))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetPaymentMethodOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<PaymentMethodDbEntity>()
            .Select(x => new FilterOptionsDto(
                Label: x.PaymentMethodName,
                Value: x.Uid.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetRefusalReasonCodeOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<RefusalReasonCodeDbEntity>()
            .Where(x => x.RefusalReasonCodeName.Contains(searchString)
                || x.RefusalReasonCodeId.ToString().StartsWith(searchString))
            .Select(x => new FilterOptionsDto(
                Label: $"{x.RefusalReasonCodeId} — основание {x.RefusalReasonCodeName}",
                Value: x.RefusalReasonCodeId.ToString()))
            .Distinct()
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetInterruptedCasePaymentReasonOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<InterruptedCasePaymentReasonDbEntity>()
            .Where(x => x.InterruptedCasePaymentReasonName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.InterruptedCasePaymentReasonName,
                Value: x.InterruptedCasePaymentReasonId))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
