using FarmGuard_Backend.Animals.Domain.Model.ValueObjects;
using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

namespace FarmGuard_Backend.Animals.Domain.Model.Aggregates;

public class Animal
{
    public int Id { get; }
    public SerialNumberAnimal SerialNumber { get; private set; }
    public string Name { get; private set; }
    public ESpecie Specie { get; private set; }
    public bool Sex { get; private set; }
    public DateTime BirthDate { get; private set; }
    
    public string urlIot { get; private set; }
    public string urlPhoto { get; private set; }
    
    /*Inventario*/
    public Section section { get; private set; }
    public int SectionId { get; private set; }
    
    
    /*Historias Medicas*/
    public MedicalHistory medicalHistory { get; private set; }
    
    /*Food*/
    public FoodDiary FoodDiary { get; private set; }
    
    
    public string Location { get; private set; }
    public long HearRate { get; private set; }
    public long Temperature { get; private set; }
    
    public Animal(){}
    public Animal(
        string name, 
        string specie, 
        string urlIot, 
        string urlPhoto, 
        string location,
        long hearRate,
        long temperature,
        int sectionId,
        bool sex,
        DateTime birthDate)
    {
        Name = name;
        SerialNumber = new SerialNumberAnimal();
        
        //Funcion para convertir en Enum
        Specie = ConvertStringToEnum(specie);

        this.urlIot = urlIot;
        this.urlPhoto = urlPhoto;


        
        Location = location;
        HearRate = hearRate;
        Temperature = temperature;
        
        SectionId= sectionId;
        Sex = sex;
        BirthDate = birthDate;
    }
    
    
    /*Funciones*/
    public ESpecie ConvertStringToEnum(string specie)
    {
        if (Enum.TryParse<ESpecie>(specie, true, out var eSpecie))
        {
            return eSpecie;
        }
        else
        {
            throw new ArgumentException($"`{specie}` is not a valid specie`");
        }
    }

    public void UpdateInformationAnimal(string name, string specie, string urlIot, string urlPhoto)
    {
        Name = name;
        Specie = ConvertStringToEnum(specie);
        this.urlIot = urlIot;
        this.urlPhoto= urlPhoto;
    }

    public void UpdateInformationIot(string location, long hearRate, long temperature)
    {
        Location = location;
        HearRate = hearRate;
        Temperature = temperature;
    }

    public bool GetDescriptionNotificationByHearRate()
    {
        // Agrupación por tipo usando los valores reales del enum
        return Specie switch
        {
            ESpecie.Vaca or ESpecie.Caballo or ESpecie.Oveja or ESpecie.Cerdo or ESpecie.Cabra => HearRate >= 60 && HearRate <= 100, // Mamíferos
            ESpecie.Pollo or ESpecie.Pato => HearRate >= 150 && HearRate <= 600, // Aves
            // Si agregas reptiles, anfibios, peces, etc. en el enum, puedes añadir aquí
            _ => false
        };
    }
    
    public bool GetDescriptionNotificationByTemperature()
    {
        // Agrupación por tipo usando los valores reales del enum
        return Specie switch
        {
            ESpecie.Vaca or ESpecie.Caballo or ESpecie.Oveja or ESpecie.Cerdo or ESpecie.Cabra => Temperature >= 36.0 && Temperature <= 38.0, // Mamíferos
            ESpecie.Pollo or ESpecie.Pato => Temperature >= 40.0 && Temperature <= 42.0, // Aves
            // Si agregas reptiles, anfibios, peces, etc. en el enum, puedes añadir aquí
            _ => false
        };
    }
}