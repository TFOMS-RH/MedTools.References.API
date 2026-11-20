using MedTools.References.API.Endpoints.Handlers;

namespace MedTools.References.API.Endpoints.Groups;

public static class ReferenceEndpoints
{
    public static IEndpointRouteBuilder RegisterReferenceEndpoints(
        this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var group = endpointRouteBuilder
            .MapGroup("/medical-references")
            .WithTags("References");

        group.MapGet(
                pattern: "/{referenceType:required}/options",
                handler: GetOptionsQuery.SendAsync)
            .WithName("GetOptions")
            .WithDescription("");

        group.MapGet(
                pattern: "/{referenceType:required}/options/search",
                handler: SearchOptionsQuery.SendAsync)
            .WithName("GetSearchOptions")
            .WithDescription("");

        return endpointRouteBuilder;
    }
}