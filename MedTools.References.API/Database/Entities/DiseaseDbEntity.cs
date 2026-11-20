namespace MedTools.References.API.Database.Entities;

public sealed class DiseaseDbEntity
{
    public int? ClassCode { get; set; }
    public int? SubClassCode { get; set; }

    public string? DiseaseCode { get; set; }
    public string? DiseaseName { get; set; }

}
