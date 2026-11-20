using MedTools.References.API.Services;

namespace MedTools.References.API.Common.Extensions.ServiceCollection;

public static class MedToolsReferenceServiceCollectionExtensions
{
    public static IServiceCollection AddMedToolReferenceServices(
        this IServiceCollection services)
    {
        services.AddScoped<MedicalReferenceOptionsService>();

        return services;
    }
}
