using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Common.Constants;
using MedTools.References.API.Database.Entities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers.Options.MedicalFields;

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
            .Where(x => x.ClinicalGroupName != null &&
                x.ClinicalGroupId.Contains(searchString))
            .Select(x => new { x.ClinicalGroupId, x.ClinicalGroupName })
            .Distinct()
            .OrderBy(x => x.ClinicalGroupId)
            .ThenBy(x => x.ClinicalGroupName)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.ClinicalGroupId} : {x.ClinicalGroupName!}",
                Value: x.ClinicalGroupId))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetComplexityCoefficientOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ComplexityCoefficientDbEntity>()
            .AsNoTracking()
            .Where(x => x.ComplexityCoefficientName != null)
            .Select(x => new { x.ComplexityCoefficientId, x.ComplexityCoefficientName })
            .Distinct()
            .OrderBy(x => x.ComplexityCoefficientId)
            .ThenBy(x => x.ComplexityCoefficientName)
            .Select(x => new FilterOptionsDto(
                Label: x.ComplexityCoefficientName!,
                Value: x.ComplexityCoefficientId))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetControlTypeCodeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<ControlTypeCodeDbEntity>()
            .AsNoTracking()
            .Where(x => x.ControlTypeCodeName != null)
            .Select(x => new { x.ControlTypeCodeId, x.ControlTypeCodeName })
            .Distinct()
            .OrderBy(x => x.ControlTypeCodeId)
            .ThenBy(x => x.ControlTypeCodeName)
            .Select(x => new FilterOptionsDto(
                Label: x.ControlTypeCodeName!,
                Value: x.ControlTypeCodeId))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetPaymentMethodOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<PaymentMethodDbEntity>()
            .AsNoTracking()
            .Distinct()
            .OrderBy(x => x.Uid)
            .ThenBy(x => x.PaymentMethodName)
            .Select(x => new FilterOptionsDto(
                Label: x.PaymentMethodName,
                Value: x.Uid.ToString()))
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
            .Select(x => new { x.RefusalReasonCodeId, x.RefusalReasonCodeName })
            .Distinct()
            .OrderBy(x => x.RefusalReasonCodeId)
            .ThenBy(x => x.RefusalReasonCodeName)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.RefusalReasonCodeId} : основание {x.RefusalReasonCodeName}",
                Value: x.RefusalReasonCodeId.ToString()))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetInterruptedCasePaymentReasonOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<InterruptedCasePaymentReasonDbEntity>()
            .AsNoTracking()
            .Where(x => x.InterruptedCasePaymentReasonName != null)
            .Select(x => new { x.InterruptedCasePaymentReasonId, x.InterruptedCasePaymentReasonName })
            .Distinct()
            .OrderBy(x => x.InterruptedCasePaymentReasonId)
            .ThenBy(x => x.InterruptedCasePaymentReasonName)
            .Select(x => new FilterOptionsDto(
                Label: x.InterruptedCasePaymentReasonName,
                Value: x.InterruptedCasePaymentReasonId))
            .ToListAsync(cancellationToken);
    }
}
