namespace FarmGuard_Backend.Shared.Application.Internal.OutboundServices;

public interface IStorageService
{
    Task<string> SaveFile(IFormFile? photo,string existingFileName,string storage);
    Task<string> UpdateFile(IFormFile? photo, string existingFileName, string storage);
}