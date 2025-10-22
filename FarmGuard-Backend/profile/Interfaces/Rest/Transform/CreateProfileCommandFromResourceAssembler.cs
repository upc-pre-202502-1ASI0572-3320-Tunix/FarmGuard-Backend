using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.profile.Domain.Model.Commands;
using FarmGuard_Backend.profile.Interfaces.Rest.resources;

namespace FarmGuard_Backend.profile.Interfaces.Rest.Transform;

public class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToResourceFromEntity(CreateProfileResource resource)
    {
        return new CreateProfileCommand(
            resource.FirstName, 
            resource.LastName, 
            resource.Email, 
            resource.Photo,
            resource.UserId);
    }
}