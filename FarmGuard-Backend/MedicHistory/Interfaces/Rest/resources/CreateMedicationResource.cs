namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

public record CreateMedicationResource(string Name, string DoseDefault, string ActiveIngredient, string RouteOfAdministration);
