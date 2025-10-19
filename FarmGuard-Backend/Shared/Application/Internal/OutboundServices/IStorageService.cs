namespace FarmGuard_Backend.Shared.Application.Internal.OutboundServices;

public interface IStorageService
{
    Task<string> SaveFile(IFormFile? photo,int sectionId);
}