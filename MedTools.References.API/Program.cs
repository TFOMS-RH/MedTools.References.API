using MedTools.References.API.Endpoints.Groups;
using MedTools.References.API.Common.Extensions.ServiceCollection;

namespace MedTools.References.API;

public sealed class Program
{
    public static async Task Main()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddMedToolReferenceServices();
        builder.Services.AddDatabaseServices(builder.Configuration);

        builder.WebHost.ConfigureKestrel(
            options =>
            {
                options.ListenAnyIP(8008);
            });

        var app = builder.Build();

        app.MapGroup("/api").RegisterReferenceEndpoints();

        await app.RunAsync();
    }
}