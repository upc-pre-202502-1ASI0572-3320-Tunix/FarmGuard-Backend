namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

public record TreatmentResource(int Id, string Title, string Notes, DateTime StartDate, bool Status, int MedicalHistoryId);
