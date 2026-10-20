namespace MedTools.References.API.Database.DbEntities;

public sealed class PhysicianSpecialtyDbEntity
{
    public int Uid { get; set; }

    public string SpecialityId { get; set; } = string.Empty;
    public string SpecialityName { get; set; } = string.Empty;
    public string? SpecialityPostname { get; set; }
}
