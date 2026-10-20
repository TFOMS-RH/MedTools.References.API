namespace MedTools.References.API.Database.DbEntities;

public sealed class ReferralTypeDbEntity
{
    public int Uid { get; set; }

    public byte ReferralId { get; set; }
    public string? ReferralName { get; set; }
}
