namespace MedTools.References.API.Database.Entities;

public sealed class MedicalCareProfileDbEntity
{
    public int Uid { get; set; }

    public int ProfileId { get; set; }
    public string ProfileName { get; set; } = string.Empty;
}
