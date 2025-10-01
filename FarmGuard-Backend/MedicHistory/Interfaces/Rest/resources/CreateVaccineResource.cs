namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

public record CreateVaccineResource(
    string Name,
    string Manufacturer,
    string Schema
);

