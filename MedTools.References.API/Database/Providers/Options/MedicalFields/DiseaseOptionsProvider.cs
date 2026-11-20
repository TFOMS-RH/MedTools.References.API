using Microsoft.EntityFrameworkCore;

using MedTools.References.API.Common.Constants;
using MedTools.References.API.Database.Entities;
using MedTools.References.API.Common.Models.Responces;

namespace MedTools.References.API.Database.Providers.Options.MedicalFields;

public sealed class DiseaseOptionsProvider(
    MedicalReferenceDbContext dbContext)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseStageOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DiseaseStageDbEntity>()
            .AsNoTracking()
            .Where(x => x.StageName != null &&
                x.StageName != "Нет" &&
                x.StageName.Contains(searchString))
            .Select(x => new { x.StageName })
            .Distinct()
            .OrderBy(x => x.StageName)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: x.StageName!,
                Value: x.StageName!))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseCharacterOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DiseaseCharacterDbEntity>()
            .AsNoTracking()
            .Where(x => x.CharacterName != null)
            .Select(x => new FilterOptionsDto(
                Label: x.CharacterName!,
                Value: x.CharacterId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseOutcomeOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DiseaseOutcomeDbEntity>()
            .AsNoTracking()
            .Select(x => new FilterOptionsDto(
                Label: x.OutcomeName,
                Value: x.OutcomeId.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseClassOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DiseaseClassDbEntity>()
            .AsNoTracking()
            .Where(x => x.ClassName != null &&
                x.StartingDiseasePrefix != null &&
                x.EndingDiseasePrefix != null &&
                x.ClassName != "Нет")
            .Select(x => new FilterOptionsDto(
                Label: $"{x.StartingDiseasePrefix!}..{x.EndingDiseasePrefix!} — {x.ClassName!}",
                Value: x.Uid.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseSubClassOptionsAsync(
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DiseaseSubClassDbEntity>()
            .AsNoTracking()
            .Where(x => x.SubClassName != null &&
                x.StartingDiseasePrefix != null &&
                x.EndingDiseasePrefix != null)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.StartingDiseasePrefix}..{x.EndingDiseasePrefix} — {x.SubClassName}",
                Value: x.Uid.ToString()))
            .Distinct()
            .OrderBy(x => x.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetDiseaseOptionsAsync(
        string searchString,
        CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<DiseaseDbEntity>()
            .AsNoTracking()
            .Where(x => x.DiseaseCode != null &&
                x.DiseaseCode != "000" &&
                x.DiseaseName != null &&
                (x.DiseaseCode.Contains(searchString) || x.DiseaseName.Contains(searchString)))
            .Select(x => new { x.DiseaseCode, x.DiseaseName })
            .Distinct()
            .OrderBy(x => x.DiseaseCode)
            .ThenBy(x => x.DiseaseName)
            .Take(OptionConstants.MaxFilterOptionsCount)
            .Select(x => new FilterOptionsDto(
                Label: $"{x.DiseaseCode!} : {x.DiseaseName!}",
                Value: x.DiseaseCode!))
            .ToListAsync(cancellationToken);
    }



}
