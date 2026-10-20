namespace MedTools.References.API.Database.DbEntities;

public sealed class DiseaseCharacterDbEntity
{
    public int Uid { get; set; } 

    public byte CharacterId { get; set; }
    public string? CharacterName { get; set; } 
}
