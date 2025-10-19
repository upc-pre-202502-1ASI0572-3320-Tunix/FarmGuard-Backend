namespace FarmGuard_Backend.MedicHistory.Domain.Model.Queries;

public record GetAllVaccinesBySectionAndDateQuery(int idSection,DateTime startDate,DateTime endDate);