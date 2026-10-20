namespace MedTools.References.API.Database.DbEntities;

public sealed class ComplexityCoefficientDbEntity
{
    public int Uid { get; set; }

    public string ComplexityCoefficientId { get; set; } = string.Empty;
    public string? ComplexityCoefficientName { get; set; }
}