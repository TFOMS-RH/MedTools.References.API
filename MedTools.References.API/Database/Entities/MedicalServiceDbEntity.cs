namespace MedTools.References.API.Database.Entities;

public sealed class MedicalServiceDbEntity
{
    public int Uid { get; set; }

    public int ServiceId { get; set; }
    public string ServiceCode { get; set; } = string.Empty;
    public string? ServiceName { get; set; }
}
