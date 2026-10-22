using MedTools.References.API.Common.Constants;
using MedTools.References.API.Common.Models.Responces;
using MedTools.References.API.Database.Providers.Options;

namespace MedTools.References.API.Services;

public sealed class ReferenceOptionsService(
    DocumentOptionsProvider documentReferenceDataProvider,
    MedicalCareOptionsProvider medicalCareOptionsProvider,
    MedicalOrganizationOptionsProvider medicalOrganizationOptionsProvider,
    MedicalServiceOptionsProvider medicalServiceOptionsProvider,
    DiseaseOptionsProvider diseaseOptionsProvider,
    PaymentOptionsProvider paymentOptionsProvider)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetFilterOptionsByReferenceCodeAsync(
        string code,
        string? searchString,
        CancellationToken cancellationToken)
    {
        return code switch
        {
            ReferenceCodes.PolicyTypes => await documentReferenceDataProvider
                .GetInsurancePolicyTypeOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.MedicalCareProfiles => await medicalCareOptionsProvider
                .GetMedicalCareProlileOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.BedProfiles => await medicalCareOptionsProvider
                .GetBedProfileOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.VisitPlaces => await medicalOrganizationOptionsProvider
                .GetVisitPlaceOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.VisitPurposes => await medicalOrganizationOptionsProvider
                .GetVisitPurposeOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.DiseaseCharacters => await diseaseOptionsProvider
                .GetDiseaseCharacterOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.PhysicianSpecialities => await medicalCareOptionsProvider
                .GetPhysicianSpecialtyOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.MedicalCareConditions => await medicalCareOptionsProvider
                .GetCareConditionOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.MedicalCareTypes => await medicalCareOptionsProvider
                .GetMedicalCareTypeOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.MedicalCareForms => await medicalCareOptionsProvider
                .GetCareFormOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.DiseaseOutcomes => await diseaseOptionsProvider
                .GetDiseaseOutcomeOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.ScreeningResults => await medicalCareOptionsProvider
                .GetScreeningResultOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.HospitalizationOutcomes => await medicalCareOptionsProvider
                .GetHospitalizationOutcomeOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.PaymentMethods => await paymentOptionsProvider
                .GetPaymentMethodOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.ReferralReasons => await medicalCareOptionsProvider
                .GetReferralReasonOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.DiseaseStages => await diseaseOptionsProvider
                .GetDiseaseStageOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken: cancellationToken),

            ReferenceCodes.OncologyServiceTypes => await medicalServiceOptionsProvider
                .GetOncologyServiceTypeOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.SurgicalTreatmentTypes => await medicalServiceOptionsProvider
                .GetSurgicalTreatmentTypeOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.RadioTherapyTypes => await medicalServiceOptionsProvider
                .GetRadioTherapyTypeOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.DrugTherapyLines => await medicalServiceOptionsProvider
                .GetDrugTherapyLineOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.DrugTherapyCycles => await medicalServiceOptionsProvider
                .GetDrugTherapyCycleOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.DrugIdentifiers => await medicalServiceOptionsProvider
                .GetDrugIdentifierOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken: cancellationToken),

            ReferenceCodes.TherapyRegimens => await medicalServiceOptionsProvider
                .GetTherapyRegimenOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken: cancellationToken),

            ReferenceCodes.DiagnosticMethods => await medicalCareOptionsProvider
                .GetDiagnosticMethodOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.MedicalServices => await medicalServiceOptionsProvider
                .GetMedicalServiceOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken: cancellationToken),

            ReferenceCodes.ReferralTypes => await medicalServiceOptionsProvider
                .GetReferralTypeOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.ClinicalGroupNumbers => await paymentOptionsProvider
                .GetClinicalGroupOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken: cancellationToken),

            ReferenceCodes.InterruptedCasePaymentReasons => await paymentOptionsProvider
                .GetInterruptedCasePaymentReasonOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.ComplexityCoefficientNumbers => await paymentOptionsProvider
                .GetComplexityCoefficientOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.HighTechCareTypes => await medicalCareOptionsProvider
                .GetHighTechCareTypeOptionsAsync(
                    searchString: searchString ?? string.Empty,
                    cancellationToken: cancellationToken),

            ReferenceCodes.HighTechCareMethods => await medicalCareOptionsProvider
                .GetHighTechCareMethodOptionsAsync(
                    searchString: searchString ?? string.Empty,
                    cancellationToken: cancellationToken),

            ReferenceCodes.ProvidedServices => await medicalServiceOptionsProvider
                .GetProvidedServiceOptionsAsync(
                    searchString: searchString ?? string.Empty,
                    cancellationToken: cancellationToken),

            ReferenceCodes.ControlTypeCodes => await paymentOptionsProvider
                .GetControlTypeCodeOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.RefusalReasonCodes => await paymentOptionsProvider
                .GetRefusalReasonCodeOptionsAsync(
                    searchString: searchString ?? string.Empty,
                    cancellationToken: cancellationToken),

            ReferenceCodes.Diseases => await diseaseOptionsProvider
                .GetDiseaseOptionsAsync(
                    searchString: searchString ?? string.Empty,
                    cancellationToken: cancellationToken),

            ReferenceCodes.DiseaseClasses => await diseaseOptionsProvider
                .GetDiseaseClassOptionsAsync(
                    cancellationToken: cancellationToken),

            ReferenceCodes.DiseaseSubClasses => await diseaseOptionsProvider
                .GetDiseaseSubClassOptionsAsync(
                    cancellationToken: cancellationToken),

            _ => throw new Exception(),
        };
    }
}
