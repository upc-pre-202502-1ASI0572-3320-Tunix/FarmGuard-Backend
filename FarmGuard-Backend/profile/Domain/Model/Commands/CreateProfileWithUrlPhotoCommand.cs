namespace FarmGuard_Backend.profile.Domain.Model.Commands;

public record CreateProfileWithUrlPhotoCommand(
    string FirstName, 
    string LastName, 
    string Email, 
    string Photo,
    int UserId);
