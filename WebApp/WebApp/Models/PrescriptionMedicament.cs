using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class PrescriptionMedicament
{
    public int IdPrescription { get; set; }
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
    public virtual Prescription Prescription { get; set; }
    public virtual Medicament Medicament { get; set; }
}