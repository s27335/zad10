namespace WebApp.Models.DTO;

public class DTOPatientPrescriptionResponse
{
    public DTOPatient Patient { get; set; }
    public List<DTOPrescription> Prescriptions;
}