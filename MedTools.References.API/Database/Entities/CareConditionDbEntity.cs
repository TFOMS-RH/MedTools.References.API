namespace MedTools.References.API.Database.Entities;

public sealed class CareConditionDbEntity
{
    public int Uid { get; set; }

    public short ConditionId { get; set; }
    public string ConditionName { get; set; } = string.Empty;
}
