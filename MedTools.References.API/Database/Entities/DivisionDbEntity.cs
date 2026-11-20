namespace MedTools.References.API.Database.Entities;

public sealed class DivisionDbEntity
{
    public int Uid { get; set; }

    public string? DivisionId { get; set; }
    public string? DivisionName { get; set; } = string.Empty;
}
