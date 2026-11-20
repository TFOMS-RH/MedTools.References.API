namespace MedTools.References.API.Database.Entities;

public sealed class VisitPurposeDbEntity
{
    public int Uid { get; set; }

    public string VisitPurposeId { get; set; } = string.Empty;
    public string? VisitPurposeName { get; set; }
};
