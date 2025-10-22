using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;

public class CreateMedicationCommandFromResourceAssembler
{
    public static CreateMedicationCommand ToCommandFromResource(CreateMedicationResource resource, int treatmentId)
    {
        return new CreateMedicationCommand(resource.Name, resource.DoseDefault, resource.ActiveIngredient, resource.RouteOfAdministration, treatmentId);
    }
}
