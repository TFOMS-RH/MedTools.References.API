namespace MedTools.References.API.Database.Entities
{
    public sealed class DiseaseStageDbEntity
    {
        public int Uid { get; set; }

        public int StageId { get; set; }
        public string? StageName { get; set; }
    }
}
