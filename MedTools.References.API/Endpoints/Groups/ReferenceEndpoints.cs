using MedTools.References.API.Endpoints.Handlers;

namespace MedTools.References.API.Endpoints.Groups;

public static class ReferenceEndpoints
{
    public static IEndpointRouteBuilder RegisterReferenceEndpoints(
        this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var group = endpointRouteBuilder
            .MapGroup("/references")
            .WithTags("References");

        group.MapGet(
                pattern: "/{code:required}/options",
                handler: GetReferenceOptionsByCodeHandler.HandleAsync)
            .WithName("GetFilterOptionsByCode");

        return endpointRouteBuilder;
    }
}