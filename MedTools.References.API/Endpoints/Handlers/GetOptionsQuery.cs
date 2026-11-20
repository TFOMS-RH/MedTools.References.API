using MedTools.References.API.Services;
using MedTools.References.API.Common.Enums;

namespace MedTools.References.API.Endpoints.Handlers;

public static class GetOptionsQuery
{
    public static async Task<IResult> SendAsync(
        MedicalReferenceType referenceType,
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

        var options = await optionsService.GetOptionsAsync(
            referenceType,
            cancellationToken);

        return Results.Ok(options);
    }
}
