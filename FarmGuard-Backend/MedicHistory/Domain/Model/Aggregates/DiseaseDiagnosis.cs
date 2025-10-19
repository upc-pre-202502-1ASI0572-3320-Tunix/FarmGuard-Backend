using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Model.ValueObjects;

namespace FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;

public class DiseaseDiagnosis
{
    public int Id { get;private set; }
    public ESeverity Severity { get; private set; }
    public string Notes { get; private set; }
    public DateTime DiagnosedAt { get; private set; }
    public  ICollection<Disease> Diseases { get; private set; }
    
    public int MedicalHistoryId { get; private set; }
    public MedicalHistory MedicalHistory { get; private set; }

    public DiseaseDiagnosis(){}

    public DiseaseDiagnosis(string severity, string notes, DateTime diagnosedAt, int medicalHistoryId)
    {
        Severity = ConvertStringToEnum(severity);
        Notes = notes;
        DiagnosedAt = diagnosedAt;
        Diseases = new List<Disease>();
        MedicalHistoryId = medicalHistoryId;
    }
    public ESeverity ConvertStringToEnum(string severity)
    {
        if (Enum.TryParse<ESeverity>(severity, out var result))
        {
            return result;
        }
        else
        {
            throw new ArgumentException(severity);
        }
    }
}