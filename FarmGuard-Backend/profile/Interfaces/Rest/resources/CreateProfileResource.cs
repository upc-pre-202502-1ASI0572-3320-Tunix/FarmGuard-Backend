namespace FarmGuard_Backend.profile.Interfaces.Rest.resources;

public record CreateProfileResource(
    string FirstName, 
    string LastName, 
    string Email, 
    IFormFile? Photo, 
    int UserId);