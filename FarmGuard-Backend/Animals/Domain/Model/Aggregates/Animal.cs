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
        return Specie switch
        {
            ESpecie.Mamíferos => HearRate >=60 && HearRate <= 100,
            ESpecie.Aves => HearRate >=150 && HearRate <= 600,
            ESpecie.Reptiles => HearRate >=10 && HearRate <= 80,
            ESpecie.Anfibios =>HearRate >=30 && HearRate <= 70,
            ESpecie.Peces =>HearRate >=10 && HearRate <= 40,
            ESpecie.Insectos => HearRate >=100 && HearRate <= 250,
            ESpecie.Arácnidos => HearRate >=30 && HearRate <= 80,
            ESpecie.Moluscos => HearRate >=5 && HearRate <= 20,
            ESpecie.Crustáceos => HearRate >=60 && HearRate <= 30,
            ESpecie.Equinodermos => HearRate >=1 && HearRate <= 5,
            _ => false

        };
        /*

        return isNormal
            ? $"La frecuencia cardíaca de {HearRate} está dentro del rango normal para la especie {Specie.ToString()}."
            : $"La frecuencia cardíaca de {HearRate} está fuera del rango normal para la especie {Specie.ToString()}.";*/
    }
    
    public bool GetDescriptionNotificationByTemperature()
    {
        return Specie switch
        {
            ESpecie.Mamíferos => Temperature >= 36.0 && Temperature <= 38.0,
            ESpecie.Aves => Temperature >= 40.0 && Temperature <= 42.0,
            ESpecie.Reptiles => Temperature >= 20.0 && Temperature <= 30.0,
            ESpecie.Anfibios => Temperature >= 15.0 && Temperature <= 25.0,
            ESpecie.Peces => Temperature >= 10.0 && Temperature <= 22.0,
            ESpecie.Insectos => Temperature >= 20.0 && Temperature <= 35.0,
            ESpecie.Arácnidos => Temperature >= 20.0 && Temperature <= 30.0,
            ESpecie.Moluscos => Temperature >= 10.0 && Temperature <= 20.0,
            ESpecie.Crustáceos => Temperature >= 10.0 && Temperature <= 20.0,
            ESpecie.Equinodermos => Temperature >= 5.0 && Temperature <= 10.0,
            _ => false

        };

        /*
        return isNormal
            ? $"La frecuencia cardíaca de {HearRate} está dentro del rango normal para la especie {Specie.ToString()}."
            : $"La frecuencia cardíaca de {HearRate} está fuera del rango normal para la especie {Specie.ToString()}.";
        */
    }
}