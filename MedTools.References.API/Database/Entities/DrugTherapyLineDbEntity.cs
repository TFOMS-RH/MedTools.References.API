namespace MedTools.References.API.Database.DbEntities;

public sealed class DrugTherapyLineDbEntity
{
    public int Uid { get; set; } 

    public int DrugTherapyLineId { get; set; }
    public string? DrugTherapyLineName { get; set; }
}
