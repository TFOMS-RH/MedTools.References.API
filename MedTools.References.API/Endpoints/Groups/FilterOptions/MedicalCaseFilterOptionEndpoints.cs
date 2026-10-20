namespace MedTools.References.API.Endpoints.Groups.FilterOptions;

public static class MedicalCaseFilterOptionEndpoints
{
    public static RouteGroupBuilder RegisterMedicalCaseFilterOptionEndpoints(
        this RouteGroupBuilder routeGroupBuilder)
    {
        var group = routeGroupBuilder
            .MapGroup("/medical-case")
            .WithTags("MedicalCaseFilterOptions");

        group.MapGet("/medical-care-profiles", () => { });

        return group;
    }
}
