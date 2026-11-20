namespace MedTools.References.API.Database.Entities;

public sealed class DrugTherapyCycleDbEntity
{
    public int Uid { get; set; }

    public int DrugTherapyCycleId { get; set; }
    public string? DrugTherapyCycleName { get; set; }
}
