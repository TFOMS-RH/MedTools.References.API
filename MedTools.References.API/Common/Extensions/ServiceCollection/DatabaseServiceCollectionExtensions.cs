using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Database;
using MedTools.References.API.Common.Models.Options;
using MedTools.References.API.Database.Providers.Options;

namespace MedTools.References.API.Common.Extensions.ServiceCollection;

public static class DatabaseServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ConfigureDatabaseOptions(services, configuration);
        RegisterDbContext(services);
        RegisterDataProviders(services);

        return services;
    }

    private static void ConfigureDatabaseOptions(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<DatabaseOptions>()
            .Bind(configuration.GetSection(DatabaseOptions.SectionName))
            .Validate(x => !string.IsNullOrWhiteSpace(x.ConnectionString)
                && x.CommandTimeoutInSeconds > 0,
                "Не указана строка подключения или время ожидания sql-запроса.")
            .ValidateOnStart();
    }

    private static void RegisterDbContext(
        IServiceCollection services)
    {
        services.AddDbContext<MedicalReferenceDbContext>((sp, dbContextOptionsBuilder) =>
        {
            var databaseOptions = sp.GetRequiredService<IOptions<DatabaseOptions>>().Value;

            dbContextOptionsBuilder.UseSqlServer(
                databaseOptions.ConnectionString,
                options =>
                {
                    options.CommandTimeout(databaseOptions.CommandTimeoutInSeconds);
                });

        });
    }

    private static void RegisterDataProviders(
        IServiceCollection services)
    {
        services.AddScoped<DiseaseOptionsProvider>();
        services.AddScoped<DocumentOptionsProvider>();
        services.AddScoped<MedicalCareOptionsProvider>();
        services.AddScoped<MedicalOrganizationOptionsProvider>();
        services.AddScoped<MedicalServiceOptionsProvider>();
        services.AddScoped<PaymentOptionsProvider>();
    }
}
