namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

public record CreateTreatmentResource(string Title, string Notes, DateTime StartDate, bool Status);
