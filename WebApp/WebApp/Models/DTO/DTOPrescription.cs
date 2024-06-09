namespace WebApp.Models.DTO;

public class DTOPrescription
{
    public int IdPrescription { get; set; }
    public ICollection<DTOMedicament> Medicaments { get; set; }
    public DTODoctor Doctor { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}