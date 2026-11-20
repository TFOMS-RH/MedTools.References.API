namespace MedTools.References.API.Database.Entities;

public sealed class ScreeningResultDbEntity
{
    public int Uid { get; set; }

    public string ScreeningResultId { get; set; } = string.Empty;
    public string? ScreeningResultName { get; set; }
}
