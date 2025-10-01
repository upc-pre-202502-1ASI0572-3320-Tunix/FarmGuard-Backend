namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

public record MedicationResource(int Id, string Name, string DoseDefault, string ActiveIngredient, string RouteOfAdministration);