namespace FarmGuard_Backend.profile.Interfaces.Rest.resources;

public record UpdateProfileResource(string FirstName, string LastName, string Email,IFormFile? file);