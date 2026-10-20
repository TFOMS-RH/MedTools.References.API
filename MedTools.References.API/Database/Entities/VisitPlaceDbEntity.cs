namespace MedTools.References.API.Database.DbEntities;

public sealed class VisitPlaceDbEntity
{
    public int Uid { get; set; }

    public string VisitPlaceId { get; set; } = string.Empty;
    public string VisitPlaceName { get; set; } = string.Empty; 
}
