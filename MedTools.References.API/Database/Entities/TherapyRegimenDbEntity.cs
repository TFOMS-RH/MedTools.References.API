namespace MedTools.References.API.Database.DbEntities;

public sealed class TherapyRegimenDbEntity
{
    public int Uid { get; set; }

    public string TherapyRegimenId { get; set; } = string.Empty;
    public string? TherapyRegimenName { get; set; }
}
