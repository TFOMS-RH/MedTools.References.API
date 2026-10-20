namespace MedTools.References.API;

public sealed class Program
{
    public static async Task Main()
    {
        var builder = WebApplication.CreateBuilder();

        var app = builder.Build();

        await app.RunAsync();
    }
}