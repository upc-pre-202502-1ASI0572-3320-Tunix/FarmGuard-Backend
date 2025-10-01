namespace FarmGuard_Backend.Animals.Application.Internal.OutboundServices;

public interface IStorageService
{
    Task<string> SaveFile(IFormFile? photo,int sectionId);
}