namespace FarmGuard_Backend.MedicHistory.Domain.Model.Commands;

public record CreateTreatmentCommand(string Title, string Notes, DateTime StartDate, bool Status, int MedicalHistoryId);
