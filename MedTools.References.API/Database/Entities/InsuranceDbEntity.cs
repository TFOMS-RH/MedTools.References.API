namespace MedTools.References.API.Database.DbEntities;

public sealed class InsuranceDbEntity
{
    public int Uid { get; set; }

    public string InsuranceCode { get; set; } = string.Empty;
    public string InsuranceShortname { get; set; } = string.Empty;

}
