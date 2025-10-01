namespace FarmGuard_Backend.MedicHistory.Domain.Model.Commands;

public record CreateMedicationCommand(string Name, string DoseDefault, string ActiveIngredient, string RouteOfAdministration, int TreatmentId);
