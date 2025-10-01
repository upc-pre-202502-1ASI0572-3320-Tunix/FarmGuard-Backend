using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using Mysqlx.Crud;

namespace FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

public class Medication
{
    public int Id { get; private set; }
    public string Name { get;private set; }
    public string ActiveIngredient { get;private set; }
    public string DoseDefault { get;private set; }
    public string RouteOfAdministration { get;private set; }
    
    //Atributos de relacion
    public int TreatmentId { get; private set; }
    public Treatment Treatment { get; private set; }
    
    public Medication(){}
    
    public Medication(string name, 
        string activeIngredient, 
        string doseDefault, 
        string routeOfAdministration,
        int treatmentId)
    {
        Name = name;
        ActiveIngredient = activeIngredient;
        DoseDefault = doseDefault;
        RouteOfAdministration = routeOfAdministration;
        TreatmentId = treatmentId;
    }
    
    public void UpdateMedication(string name, string activeIngredient, string doseDefault, string routeOfAdministration)
    {
        Name = name;
        ActiveIngredient = activeIngredient;
        DoseDefault = doseDefault;
        RouteOfAdministration = routeOfAdministration;
    }
}