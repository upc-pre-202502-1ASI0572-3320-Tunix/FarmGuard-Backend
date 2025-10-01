using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;

public class TreatmentResourceFromEntityAssembler
{
    public static TreatmentResource ToEntityFromResource(Treatment treatment)
    {
        return new TreatmentResource(treatment.Id, treatment.Title, treatment.Notes, treatment.StartDate, treatment.Status, treatment.MedicalHistoryId);
    }
}
