namespace MedTools.References.API.Database.DbEntities;

public sealed class ReferralReasonDbEntity
{
    public int Uid { get; set; }

    public int ReferralReasonId { get; set; }
    public string? ReferralReasonName { get; set; }
}
