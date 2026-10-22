using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Common.Models.Responces;
using MedTools.References.API.Database.DbEntities;

namespace MedTools.References.API.Database.Providers.Options;

public sealed class DiseaseOptionsProvider(
    MedicalReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseCharacterOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DiseaseCharacterDbEntity>()
            .Where(x => x.CharacterName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.CharacterName!,
                Value: x.CharacterId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseOutcomeOptionsAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Set<DiseaseOutcomeDbEntity>()
            .Select(x => new FilterOptionsDto(
                Label: x.OutcomeName,
                Value: x.OutcomeId.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseClassOptionsAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Set<DiseaseClassDbEntity>()
            .Where(x => x.ClassName != null
                && x.StartingDiseasePrefix != null
                && x.EndingDiseasePrefix != null
                && x.ClassName != "Нет")
            .Select(x => new FilterOptionsDto(
                Label: $"{x.StartingDiseasePrefix!}..{x.EndingDiseasePrefix!} — {x.ClassName!}",
                Value: x.Uid.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseSubClassOptionsAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Set<DiseaseSubClassDbEntity>()
            .Where(x => x.SubClassName != null
                && x.StartingDiseasePrefix != null
                && x.EndingDiseasePrefix != null)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.StartingDiseasePrefix}..{x.EndingDiseasePrefix} — {x.SubClassName}",
                Value: x.Uid.ToString()))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseOptionsAsync(
        string searchString,
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Set<DiseaseDbEntity>()
            .Where(x => x.DiseaseCode != null
                && x.DiseaseCode != "000"
                && x.DiseaseName != null
                && (x.DiseaseCode.Contains(searchString) || x.DiseaseName.Contains(searchString)))
            .Select(x => new FilterOptionsDto(
                Label: x.DiseaseName!,
                Value: x.DiseaseCode!))
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseStageOptionsAsync(
        string searchString,
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Set<DiseaseStageDbEntity>()
            .Where(x => x.StageName != null 
                && x.StageName != "Нет" 
                && x.StageName.Contains(searchString))
            .Select(x => new FilterOptionsDto(
                Label: x.StageName!,
                Value: x.StageId.ToString()))
            .Distinct()
            .Take(30)
            .ToListAsync(cancellationToken: cancellationToken);
    }

}
