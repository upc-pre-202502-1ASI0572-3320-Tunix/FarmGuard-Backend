namespace FarmGuard_Backend.Animals.Interfaces.Hubs.resources;

public record TelemetryResource(
    string device_id,
    float bpm,
    float temperature,
    string location
    );