using MedTools.References.API.Services;

namespace MedTools.References.API.Endpoints.Handlers;

public static class GetReferenceOptionsByCodeHandler
{
    public static async Task<IResult> HandleAsync(
        string code,
        string? searchString,
        ReferenceOptionsService referenceOptionsService,
        CancellationToken cancellationToken)
    {
        var filterOptions = await referenceOptionsService.GetFilterOptionsByReferenceCodeAsync(
            code: code,
            searchString: searchString,
            cancellationToken: cancellationToken);

        return Results.Ok(filterOptions);
    }
}
