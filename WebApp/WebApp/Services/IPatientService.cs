using WebApp.Models.DTO;

namespace WebApp.Services;

public interface IPatientService
{
    public Task<DTOPatientPrescriptionResponse?> GetPatient(int id, CancellationToken cancellationToken);
}