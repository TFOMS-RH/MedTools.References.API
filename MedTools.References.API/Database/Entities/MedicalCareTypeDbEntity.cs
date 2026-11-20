namespace MedTools.References.API.Database.Entities;

public sealed class MedicalCareTypeDbEntity
{
    public short Uid { get; set; }

    public string MedicalCareName { get; set; } = string.Empty;
}
