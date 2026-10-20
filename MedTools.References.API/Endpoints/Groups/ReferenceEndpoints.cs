using MedTools.References.API.Endpoints.Groups.FilterOptions;

namespace MedTools.References.API.Endpoints.Groups;

public static class ReferenceEndpoints
{
    public static IEndpointRouteBuilder RegisterReferenceEndpoints(
        this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var filterOptionsGroup = endpointRouteBuilder
            .MapGroup("/filter-options")
            .WithTags("FilterOptions");

        filterOptionsGroup.RegisterMedicalCaseFilterOptionEndpoints();

        return endpointRouteBuilder;
    }
}
