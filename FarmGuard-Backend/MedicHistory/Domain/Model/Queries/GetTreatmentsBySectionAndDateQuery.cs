namespace FarmGuard_Backend.MedicHistory.Domain.Model.Queries;

public record GetTreatmentsBySectionAndDateQuery(int idSection, DateTime startDate,  DateTime endDate);