using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;

public class MedicationResourceFromEntityAssembler
{
    public static MedicationResource ToEntityFromResource(Medication medication)
    {
        return new MedicationResource(medication.Id, medication.Name, medication.DoseDefault, medication.ActiveIngredient, medication.RouteOfAdministration);
    }
}
