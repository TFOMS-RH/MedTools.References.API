using MedTools.References.API.Common.Enums;
using MedTools.References.API.Common.Models.Responces;
using MedTools.References.API.Database.Providers.Options;

namespace MedTools.References.API.Services;

public sealed class MedicalReferenceOptionsService(
    MedicalReferenceOptionsProvider provider)
{
    public async Task<IReadOnlyCollection<FilterOptionsDto>> GetOptionsAsync(
        MedicalReferenceType referenceType,
        CancellationToken cancellationToken)
    {
        return referenceType switch
        {
            MedicalReferenceType.F008 => await provider.DocumentOptions
                .GetInsurancePolicyTypeOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V002 => await provider.MedicalCareOptions
                .GetMedicalCareProlileOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V020 => await provider.MedicalCareOptions
                .GetBedProfileOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V040 => await provider.MedicalOrgOptions
                .GetVisitPlaceOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V025 => await provider.MedicalOrgOptions
                .GetVisitPurposeOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V027 => await provider.DiseaseOptions
                .GetDiseaseCharacterOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V021 => await provider.MedicalCareOptions
                .GetPhysicianSpecialtyOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V006 => await provider.MedicalCareOptions
                .GetCareConditionOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V008 => await provider.MedicalCareOptions
                .GetMedicalCareTypeOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V014 => await provider.MedicalCareOptions
                .GetCareFormOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V012 => await provider.DiseaseOptions
                .GetDiseaseOutcomeOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V017 => await provider.MedicalCareOptions
                .GetScreeningResultOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V009 => await provider.MedicalCareOptions
                .GetHospitalizationOutcomeOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V010 => await provider.PaymentOptions
                .GetPaymentMethodOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.N018 => await provider.MedicalCareOptions
                .GetReferralReasonOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.N013 => await provider.MedicalServiceOptions
                .GetOncologyServiceTypeOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.N014 => await provider.MedicalServiceOptions
                .GetSurgicalTreatmentTypeOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.N017 => await provider.MedicalServiceOptions
                .GetRadioTherapyTypeOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.N015 => await provider.MedicalServiceOptions
                .GetDrugTherapyLineOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.N016 => await provider.MedicalServiceOptions
                .GetDrugTherapyCycleOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V029 => await provider.MedicalCareOptions
                .GetDiagnosticMethodOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V028 => await provider.MedicalServiceOptions
                .GetReferralTypeOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V042 => await provider.PaymentOptions
                .GetInterruptedCasePaymentReasonOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.V041 => await provider.PaymentOptions
                .GetComplexityCoefficientOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.F006 => await provider.PaymentOptions
                .GetControlTypeCodeOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.ICD_CLASSES => await provider.DiseaseOptions
                .GetDiseaseClassOptionsAsync(
                    cancellationToken),

            MedicalReferenceType.ICD_SUBCLASSES => await provider.DiseaseOptions
                .GetDiseaseSubClassOptionsAsync(
                    cancellationToken),

            _ => [],
        };
    }

    public async Task<IReadOnlyCollection<FilterOptionsDto>> SearchOptionsAsync(
        MedicalReferenceType referenceType,
        string searchString,
        CancellationToken cancellationToken)
    {
        return referenceType switch
        {
            MedicalReferenceType.F032 => await provider.MedicalOrgOptions
                .GetMedicalOrgOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.F002 => await provider.MedicalOrgOptions
                .GetInsuranceOrgOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.N002 => await provider.DiseaseOptions
                .GetDiseaseStageOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.N020 => await provider.MedicalServiceOptions
                .GetDrugIdentifierOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.V024 => await provider.MedicalServiceOptions
                .GetTherapyRegimenOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.V001 => await provider.MedicalServiceOptions
                .GetMedicalServiceOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.V023 => await provider.PaymentOptions
                .GetClinicalGroupOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.V018 => await provider.MedicalCareOptions
                .GetHighTechCareTypeOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.V019 => await provider.MedicalCareOptions
                .GetHighTechCareMethodOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.T003 => await provider.MedicalServiceOptions
                .GetProvidedServiceOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.F014 => await provider.PaymentOptions
                .GetRefusalReasonCodeOptionsAsync(
                    searchString,
                    cancellationToken),

            MedicalReferenceType.ICD => await provider.DiseaseOptions
                .GetDiseaseOptionsAsync(
                    searchString,
                    cancellationToken),

            _ => []

        };
    }
}