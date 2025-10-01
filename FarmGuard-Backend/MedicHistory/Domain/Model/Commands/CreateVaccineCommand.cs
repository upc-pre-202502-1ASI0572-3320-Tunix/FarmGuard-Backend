namespace FarmGuard_Backend.MedicHistory.Domain.Model.Commands;

public record CreateVaccineCommand(string name, string manufacturer, string schema, int medicalHistoryId);

