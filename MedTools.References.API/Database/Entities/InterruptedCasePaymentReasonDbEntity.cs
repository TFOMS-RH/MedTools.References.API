namespace MedTools.References.API.Database.Entities;

public sealed class InterruptedCasePaymentReasonDbEntity
{
    public int Uid { get; set; }

    public string InterruptedCasePaymentReasonId { get; set; } = string.Empty;
    public string InterruptedCasePaymentReasonName { get; set; } = string.Empty;
}
