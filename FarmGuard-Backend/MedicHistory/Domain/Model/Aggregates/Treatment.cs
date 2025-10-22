using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

namespace FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;

public class Treatment
{
    public int Id { get;private set; }
    public string Title { get;private set; }
    public string Notes { get;private set; }
    public DateTime StartDate { get;private set; }
    public bool Status { get; private set; }
    public ICollection<Medication> Medications { get; private set; }
    
    public int MedicalHistoryId { get; private set; }
    public MedicalHistory MedicalHistory { get; private set; }
    
    
    public Treatment(){}
    public Treatment(string title, string notes, DateTime startDate, bool status, int medicalHistoryId)
    {
        Title = title;
        Notes = notes;
        StartDate = startDate;
        Status = status;
        MedicalHistoryId = medicalHistoryId;
        Medications = new List<Medication>();
    }
    
    public void UpdateTreatment(string title, string notes, DateTime startDate, bool status)
    {
        Title = title;
        Notes = notes;
        StartDate = startDate;
        Status = status;
    }

    public void AddMedication(string name, string activeIngredient, string doseDefault, string routeOfAdministration, int medicalHistoryId)
    {
        Medications.Add(
            new Medication(name, activeIngredient, doseDefault, routeOfAdministration, medicalHistoryId));
    }
    public void DeleteMedication(Medication medication)
    {
        Medications.Remove(medication);
    }

    public void UpdateMedication(Medication medication)
    {
        
    }
}