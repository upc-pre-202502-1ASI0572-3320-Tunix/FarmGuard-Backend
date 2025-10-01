using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;

public class CreateTreatmentCommandFromResourceAssembler
{
    public static CreateTreatmentCommand ToCommandFromResource(CreateTreatmentResource resource,int medicalHistoryId)
    {
        return new CreateTreatmentCommand(resource.Title, resource.Notes, resource.StartDate, resource.Status, medicalHistoryId);
    }
}
