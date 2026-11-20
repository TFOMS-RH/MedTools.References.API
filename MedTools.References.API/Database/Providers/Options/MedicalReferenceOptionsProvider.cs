using MedTools.References.API.Database.Providers.Options.MedicalFields;

namespace MedTools.References.API.Database.Providers.Options;

public sealed class MedicalReferenceOptionsProvider(
    PaymentOptionsProvider paymentOptionsProvider,
    DiseaseOptionsProvider diseaseOptionsProvider,
    DocumentOptionsProvider documentOptionsProvider,
    MedicalOrgOptionsProvider medicalOrgOptionsProvider,
    MedicalCareOptionsProvider medicalCareOptionsProvider,
    MedicalServiceOptionsProvider medicalServiceOptionsProvider)
{
    public PaymentOptionsProvider PaymentOptions { get; init; } = paymentOptionsProvider;
    public DiseaseOptionsProvider DiseaseOptions { get; init; } = diseaseOptionsProvider;
    public DocumentOptionsProvider DocumentOptions { get; init; } = documentOptionsProvider;
    public MedicalOrgOptionsProvider MedicalOrgOptions { get; init; } = medicalOrgOptionsProvider;
    public MedicalCareOptionsProvider MedicalCareOptions { get; init; } = medicalCareOptionsProvider;
    public MedicalServiceOptionsProvider MedicalServiceOptions { get; init; } = medicalServiceOptionsProvider;
}