namespace MedTools.References.API.Database.Entities;

public sealed class OncologyServiceTypeDbEntity
{
    public int Uid { get; set; }

    public int ServiceId { get; set; }
    public string? ServiceName { get; set; }
}
