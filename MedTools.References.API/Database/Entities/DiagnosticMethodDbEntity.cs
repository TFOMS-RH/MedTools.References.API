namespace MedTools.References.API.Database.DbEntities;

public sealed class DiagnosticMethodDbEntity
{
    public int Uid { get; set; }

    public byte DiagnosticMethodId { get; set; }
    public string? DiagnosticMethodName { get; set; }
}
