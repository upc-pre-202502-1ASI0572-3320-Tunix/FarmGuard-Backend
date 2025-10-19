using FarmGuard_Backend.profile.Application.Internal.OutboundServices;
using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.profile.Domain.Model.Commands;
using FarmGuard_Backend.profile.Domain.Repositories;
using FarmGuard_Backend.profile.Domain.Services;
using FarmGuard_Backend.Shared.Application.Internal.OutboundServices;
using FarmGuard_Backend.Shared.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FarmGuard_Backend.profile.Application.Internal.ComandServices;

/// <summary>
/// Profile command service 
/// </summary>
/// <param name="profileRepository">
/// Profile repository
/// </param>
/// <param name="unitOfWork">
/// Unit of work
/// </param>
/// <param name="externalInventoryService">
/// ExternalInventoryService
/// </param>
public class ProfileCommandService(
    IProfileRepository profileRepository,
    IUnitOfWork unitOfWork,
    IStorageService storageService,
    ExternalInventoryService externalInventoryService):IProfileCommandService
{
    
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        try
        {
            /*Verificamos si existe un perfil con ese correo*/
            
            bool existbyEmail = await profileRepository.GetProfileByEmail(command.Email);
            
            if( existbyEmail) throw new Exception("Existe el email con el correo");
            
            var urlPhoto = await storageService.SaveFile(command.Photo,$"{command.UserId}","profiles");
            
            var profile = new Profile(
                command.FirstName,
                command.LastName,
                command.Email,
                urlPhoto,
                command.UserId);
            
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"New Profile: {profile.Id}");
            Console.ForegroundColor = ConsoleColor.White;
            
            /*Creamos inventario*/
            
            var idInventory = await externalInventoryService.CreateInventoryWithProfile($"{profile.Name.FirstName} inventory", profile.Id);
            
            if(idInventory is null)  throw new Exception("Inventory no creado");
            
            /*Asignamos inventario al perfil*/
            
            profile.AssignInventory(idInventory.Value);
            
            // Guardamos los cambios nuevamente
            profileRepository.Update(profile);
            await unitOfWork.CompleteAsync();
            
            return profile;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    
    public async Task<Profile?> Handle(CreateProfileWithUrlPhotoCommand command)
    {
        try
        {
            /*Verificamos si existe un perfil con ese correo*/
            
            bool existbyEmail = await profileRepository.GetProfileByEmail(command.Email);
            
            if( existbyEmail) throw new Exception("Existe el email con el correo");
            
            
            
            var profile = new Profile(
                command.FirstName,
                command.LastName,
                command.Email,
                command.Photo,
                command.UserId);
            
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"New Profile: {profile.Id}");
            Console.ForegroundColor = ConsoleColor.White;
            
            /*Creamos inventario*/
            
            var idInventory = await externalInventoryService.CreateInventoryWithProfile($"{profile.Name.FirstName} inventory", profile.Id);
            
            if(idInventory is null)  throw new Exception("Inventory no creado");
            
            /*Asignamos inventario al perfil*/
            
            profile.AssignInventory(idInventory.Value);
            
            // Guardamos los cambios nuevamente
            profileRepository.Update(profile);
            await unitOfWork.CompleteAsync();
            
            return profile;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<Profile?> Handle(UpdateProfileCommand command)
    {
        try
        {
            var profile = await profileRepository.FindByIdAsync(command.Id);
            if(profile is null) throw new Exception($"No se pudo encontrar el perfil con el Id {command.Id}");
        
            
            
            
            /*Servicio de FireBase*/
            
            var urlPhoto = await storageService.UpdateFile(command.Photo,$"{profile.UserId}","profiles");
            
            profile.UpdateEmail(command.Email);
            profile.UpdateUrlPhoto(urlPhoto);
        
            profileRepository.Update(profile);
            await unitOfWork.CompleteAsync();
            return profile;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    public async Task<Profile?> Handle(DeleteProfileByIdCommand command)
    {
        var profile = await profileRepository.FindByIdAsync(command.id);
        profileRepository.Remove(profile);
        await unitOfWork.CompleteAsync();
        return profile;
    }
}