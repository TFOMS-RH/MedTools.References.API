using MedTools.References.API.Common.Constants;
using MedTools.References.API.Database.Providers;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Services;

public sealed class ReferenceOptionsService(
    IServiceScopeFactory serviceScopeFactory)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetFilterOptionsByReferenceCodeAsync(
        string code,
        string? searchString,
        CancellationToken cancellationToken)
    {

        using var scope = serviceScopeFactory.CreateScope();

        var documentReferenceDataProvider = scope.ServiceProvider.GetRequiredService<DocumentReferenceDataProvider>();

        return code switch
        {
            ReferenceCodes.PolicyTypes => await documentReferenceDataProvider.GetInsurancePolicyTypesAsync(
                cancellationToken: cancellationToken),

            _ => throw new Exception(),
        };
    }
}
