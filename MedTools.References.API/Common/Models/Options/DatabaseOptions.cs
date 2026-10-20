namespace MedTools.References.API.Common.Models.Options;

public sealed class DatabaseOptions
{
    public const string SectionName = "Database";

    public string ConnectionString { get; set; } = string.Empty;
    public int CommandTimeoutInSeconds { get; set; }
}
