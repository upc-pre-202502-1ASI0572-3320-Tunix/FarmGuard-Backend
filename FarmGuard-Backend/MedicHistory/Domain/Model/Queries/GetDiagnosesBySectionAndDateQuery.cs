namespace FarmGuard_Backend.MedicHistory.Domain.Model.Queries;

public record GetDiagnosesBySectionAndDateQuery(int idSection, DateTime startDate,  DateTime endDate);
