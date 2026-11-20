using MedTools.References.API.Services;
using MedTools.References.API.Common.Enums;

namespace MedTools.References.API.Endpoints.Handlers;

public static class SearchOptionsQuery
{
    public static async Task<IResult> SendAsync(
        MedicalReferenceType referenceType,
        string searchString,
        MedicalReferenceOptionsService optionsService,
        CancellationToken cancellationToken)
    {
        if (!Enum.IsDefined(referenceType))
        {
            return Results.ValidationProblem(
                new Dictionary<string, string[]>
                {
                    ["referenceType"] = ["Неизвестный тип справочника"]
                });
        }

        if (string.IsNullOrWhiteSpace(searchString))
        {
            return Results.BadRequest();
        }

        var options = await optionsService.SearchOptionsAsync(
            referenceType,
            searchString.Trim(),
            cancellationToken);

        return Results.Ok(options);
    }
}