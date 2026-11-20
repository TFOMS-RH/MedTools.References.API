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
            ReferenceCodes.MedicalOrgs => await medicalOrganizationOptionsProvider
                .GetMedicalOrgOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.InsuranceOrgs => await medicalOrganizationOptionsProvider
                .GetInsuranceOrgOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.PolicyTypes => await documentReferenceDataProvider
                .GetInsurancePolicyTypeOptionsAsync(
                    cancellationToken),

            ReferenceCodes.MedicalCareProfiles => await medicalCareOptionsProvider
                .GetMedicalCareProlileOptionsAsync(
                    cancellationToken),

            ReferenceCodes.BedProfiles => await medicalCareOptionsProvider
                .GetBedProfileOptionsAsync(
                    cancellationToken),

            ReferenceCodes.VisitPlaces => await medicalOrganizationOptionsProvider
                .GetVisitPlaceOptionsAsync(
                    cancellationToken),

            ReferenceCodes.VisitPurposes => await medicalOrganizationOptionsProvider
                .GetVisitPurposeOptionsAsync(
                    cancellationToken),

            ReferenceCodes.DiseaseCharacters => await diseaseOptionsProvider
                .GetDiseaseCharacterOptionsAsync(
                    cancellationToken),

            ReferenceCodes.PhysicianSpecialities => await medicalCareOptionsProvider
                .GetPhysicianSpecialtyOptionsAsync(
                    cancellationToken),

            ReferenceCodes.MedicalCareConditions => await medicalCareOptionsProvider
                .GetCareConditionOptionsAsync(
                    cancellationToken),

            ReferenceCodes.MedicalCareTypes => await medicalCareOptionsProvider
                .GetMedicalCareTypeOptionsAsync(
                    cancellationToken),

            ReferenceCodes.MedicalCareForms => await medicalCareOptionsProvider
                .GetCareFormOptionsAsync(
                    cancellationToken),

            ReferenceCodes.DiseaseOutcomes => await diseaseOptionsProvider
                .GetDiseaseOutcomeOptionsAsync(
                    cancellationToken),

            ReferenceCodes.ScreeningResults => await medicalCareOptionsProvider
                .GetScreeningResultOptionsAsync(
                    cancellationToken),

            ReferenceCodes.HospitalizationOutcomes => await medicalCareOptionsProvider
                .GetHospitalizationOutcomeOptionsAsync(
                    cancellationToken),

            ReferenceCodes.PaymentMethods => await paymentOptionsProvider
                .GetPaymentMethodOptionsAsync(
                    cancellationToken),

            ReferenceCodes.ReferralReasons => await medicalCareOptionsProvider
                .GetReferralReasonOptionsAsync(
                    cancellationToken),

            ReferenceCodes.DiseaseStages => await diseaseOptionsProvider
                .GetDiseaseStageOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.OncologyServiceTypes => await medicalServiceOptionsProvider
                .GetOncologyServiceTypeOptionsAsync(
                    cancellationToken),

            ReferenceCodes.SurgicalTreatmentTypes => await medicalServiceOptionsProvider
                .GetSurgicalTreatmentTypeOptionsAsync(
                    cancellationToken),

            ReferenceCodes.RadioTherapyTypes => await medicalServiceOptionsProvider
                .GetRadioTherapyTypeOptionsAsync(
                    cancellationToken),

            ReferenceCodes.DrugTherapyLines => await medicalServiceOptionsProvider
                .GetDrugTherapyLineOptionsAsync(
                    cancellationToken),

            ReferenceCodes.DrugTherapyCycles => await medicalServiceOptionsProvider
                .GetDrugTherapyCycleOptionsAsync(
                    cancellationToken),

            ReferenceCodes.DrugIdentifiers => await medicalServiceOptionsProvider
                .GetDrugIdentifierOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.TherapyRegimens => await medicalServiceOptionsProvider
                .GetTherapyRegimenOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.DiagnosticMethods => await medicalCareOptionsProvider
                .GetDiagnosticMethodOptionsAsync(
                    cancellationToken),

            ReferenceCodes.MedicalServices => await medicalServiceOptionsProvider
                .GetMedicalServiceOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.ReferralTypes => await medicalServiceOptionsProvider
                .GetReferralTypeOptionsAsync(
                    cancellationToken),

            ReferenceCodes.ClinicalGroupNumbers => await paymentOptionsProvider
                .GetClinicalGroupOptionsAsync(
                    searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.InterruptedCasePaymentReasons => await paymentOptionsProvider
                .GetInterruptedCasePaymentReasonOptionsAsync(
                    cancellationToken),

            ReferenceCodes.ComplexityCoefficientNumbers => await paymentOptionsProvider
                .GetComplexityCoefficientOptionsAsync(
                    cancellationToken),

            ReferenceCodes.HighTechCareTypes => await medicalCareOptionsProvider
                .GetHighTechCareTypeOptionsAsync(
                    searchString: searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.HighTechCareMethods => await medicalCareOptionsProvider
                .GetHighTechCareMethodOptionsAsync(
                    searchString: searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.ProvidedServices => await medicalServiceOptionsProvider
                .GetProvidedServiceOptionsAsync(
                    searchString: searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.ControlTypeCodes => await paymentOptionsProvider
                .GetControlTypeCodeOptionsAsync(
                    cancellationToken),

            ReferenceCodes.RefusalReasonCodes => await paymentOptionsProvider
                .GetRefusalReasonCodeOptionsAsync(
                    searchString: searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.Diseases => await diseaseOptionsProvider
                .GetDiseaseOptionsAsync(
                    searchString: searchString ?? string.Empty,
                    cancellationToken),

            ReferenceCodes.DiseaseClasses => await diseaseOptionsProvider
                .GetDiseaseClassOptionsAsync(
                    cancellationToken),

            ReferenceCodes.DiseaseSubClasses => await diseaseOptionsProvider
                .GetDiseaseSubClassOptionsAsync(
                    cancellationToken),

            _ => throw new Exception(),
        };
    }
}
