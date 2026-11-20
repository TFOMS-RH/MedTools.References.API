namespace MedTools.References.API.Database.Entities;

public sealed class DiseaseOutcomeDbEntity
{
    public int Uid { get; set; }

    public short OutcomeId { get; set; }
    public string OutcomeName { get; set; } = string.Empty;
}
