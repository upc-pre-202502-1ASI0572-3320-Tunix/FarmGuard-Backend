using FarmGuard_Backend.Animals.Application.Internal.OutboundServices;
using FarmGuard_Backend.Shared.Application.Internal.OutboundServices;
using Firebase.Storage;

namespace FarmGuard_Backend.Shared.Infrastructure.FireBase;

public class StorageService: IStorageService
{
    public async Task<string> SaveFile(IFormFile? photo,int sectionId)
    {
        //Libera memoria usada el using
        using var stream = photo?.OpenReadStream();
        
        var url  = await new FirebaseStorage("farmguard-993d2.firebasestorage.app")
            .Child("animals")
            .Child(sectionId.ToString())
            .Child(photo?.FileName ?? "NoName")
            .PutAsync(stream);

        return url;


    }
}