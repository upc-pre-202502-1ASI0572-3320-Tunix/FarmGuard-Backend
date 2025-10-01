using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

namespace FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;

public class DiseaseDiagnosis
{
    public int Id { get;private set; }
    public string Severity { get; private set; }
    public string Notes { get; private set; }
    public DateTime DiagnosedAt { get; private set; }
    public  ICollection<Disease> Diseases { get; private set; }
    
    public int MedicalHistoryId { get; private set; }
    public MedicalHistory MedicalHistory { get; private set; }

    public DiseaseDiagnosis(){}

    public DiseaseDiagnosis(string severity, string notes, DateTime diagnosedAt, int medicalHistoryId)
    {
        Severity = severity;
        Notes = notes;
        DiagnosedAt = diagnosedAt;
        Diseases = new List<Disease>();
        MedicalHistoryId = medicalHistoryId;
    }
}