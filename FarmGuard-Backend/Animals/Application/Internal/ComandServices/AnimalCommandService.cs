using FarmGuard_Backend.Animals.Application.Internal.OutboundServices;
using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.ComandServices;

public class AnimalCommandService(IAnimalRepository animalRepository,
    IUnitOfWork unitOfWork,
    ExternalNotificationService externalNotificationService,
    IStorageService storageService,
    IMedicalHistoryRepository medicalHistoryRepository,
    IIventoryRepository inIventoryRepository,
    IFoodDiaryRepository foodDiaryRepository):IAnimalCommandService
    
    
{
    public async Task<Animal?> Handle(CreateAnimalCommand command)
    {
        try
        {
            /*Aca iria las reglas del negocio*/
            var inventory = await inIventoryRepository.FindByIdAsync(command.inventoryId);
            if (inventory is null) throw new Exception("Inventory not found");
            if (command.Photo is null) throw new ArgumentNullException(nameof(command.Photo), "Photo cannot be null");
            if (command.Photo.Length > 5_000_000) // 5 MB
                throw new InvalidOperationException("El archivo excede el tamaño máximo permitido (5 MB).");
            
            //Guardar imagen en el servicio de almacenamiento
            var urlPhoto = await storageService.SaveFile(command.Photo,inventory.Id);
            

            
            /*Aqui se crea la la entidad animal*/
            var animal = new Animal(
                command.name, 
                command.specie, 
                command.urlIot, 
                urlPhoto, 
                command.location,
                command.hearRate, 
                command.temperature,
                inventory.Id,
                command.sex,
                command.birthDate);
            
            
            /*Aca se guarda en db por transaccion*/
            await animalRepository.AddAsync(animal);
;
            
            
            //Crear historial medico vacio
            await medicalHistoryRepository.AddAsync(new MedicalHistory(animal));
            
            //Crear el diario de comida vacio
            var foodDiary = new FoodDiary(animal, DateTime.UtcNow);
            await foodDiaryRepository.AddAsync(foodDiary);
            
            
            await unitOfWork.CompleteAsync();
            

            return animal;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Animal?> Handle(PutAnimalCommand command)
    {
        try
        {
            var animal = await animalRepository.FindAnimalBySerialNumberIdAsync(command.AnimalId);
            if (animal is null) throw new Exception("No se encontro animal con Cierta Id Animal");
            
            /*aActualizamos los datos*/
            
            animal.UpdateInformationAnimal(command.Name,command.Specie,command.UrlIot,command.UrlPhoto);
            animal.UpdateInformationIot(command.Location,command.HearRate,command.Temperature);
            
            /*Verificamos si la temperatura esta en su rango y vemos si creamos notificaciones*/

            var controlTemperature = animal.GetDescriptionNotificationByTemperature();
            var controlHearRate = animal.GetDescriptionNotificationByHearRate();
            
            //Creamos variables para pasar

            var tittle = $"Notification of {animal.Name}";
            var inventoryId = animal.SectionId;

            if (controlTemperature)
            {
                var state = "Low";
                var description =
                    $"La frecuencia cardíaca de {animal.Temperature} está dentro del rango normal para la especie {animal.Specie.ToString()}.";
                await externalNotificationService.CreateNotification(tittle,description,state,inventoryId);
            }
            else
            {
                var state = "High";
                var description =$"La frecuencia cardíaca de {animal.Temperature} está fuera del rango normal para la especie {animal.Specie.ToString()}.";
                await externalNotificationService.CreateNotification(tittle,description,state,inventoryId);
                
            }

            if (controlHearRate)
            {
                var state = "Low";
                var description = $"La Temperatura de {animal.HearRate} está dentro del rango normal para la especie {animal.Specie.ToString()}.";
                await externalNotificationService.CreateNotification(tittle,description,state,inventoryId);
            }
            else
            {
                var state = "High";
                var description =$"La Temperatura de {animal.HearRate} está fuera del rango normal para la especie {animal.Specie.ToString()}.";
                await externalNotificationService.CreateNotification(tittle,description,state,inventoryId);
            }
            
            
            
                
            
            /*Verificamos si el ritmo cardiaco esta en su rango*/
            
            animalRepository.Update(animal);
            await unitOfWork.CompleteAsync();
            
            return animal;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Animal?> Handle(DeleteAnimalByIdAnimalCommand command)
    {
        var animal = await animalRepository.FindAnimalBySerialNumberIdAsync(command.AnimalId);
        if (animal is null) throw new Exception("No se encontro animal con Certa Id Animal");
        
        animalRepository.Remove(animal);
        await unitOfWork.CompleteAsync();

        return animal;
    }
}