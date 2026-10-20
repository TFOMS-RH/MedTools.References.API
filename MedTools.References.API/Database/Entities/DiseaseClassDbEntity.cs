namespace MedTools.References.API.Database.DbEntities;

public sealed class DiseaseClassDbEntity
{
    public int Uid { get; set; }

    public string? ClassName { get; set; }
    public string? StartingDiseasePrefix { get; set; }
    public string? EndingDiseasePrefix { get; set; }
}
