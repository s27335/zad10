namespace WebApp.Models.DTO;

public class AddPrescription
{
    public DTOPatient Patient { get; set; }
    public ICollection<DTOMedicament> Medicaments { get; set; }
    public int IdDoctor { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}