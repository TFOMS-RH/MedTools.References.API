namespace MedTools.References.API.Database.Entities;

public sealed class InsurancePolicyTypeDbEntity
{
    public int Uid { get; set; }

    public string DocumentId { get; set; } = string.Empty;
    public string DocumentName { get; set; } = string.Empty;
}
