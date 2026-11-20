namespace MedTools.References.API.Database.Entities;

public sealed class CareFormDbEntity
{
    public int Uid { get; set; }

    public short CareFormId { get; set; }
    public string? CareFormName { get; set; }
}
