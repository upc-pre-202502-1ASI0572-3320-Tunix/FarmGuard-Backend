namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

public record class CreateDiseaseDiagnosisResource(string Severity, string Notes, DateTime DiagnosedAt);