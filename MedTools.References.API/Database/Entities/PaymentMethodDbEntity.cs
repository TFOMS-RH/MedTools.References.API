namespace MedTools.References.API.Database.Entities;

public sealed class PaymentMethodDbEntity
{
    public short Uid { get; set; }

    public string PaymentMethodName { get; set; } = string.Empty;
}
