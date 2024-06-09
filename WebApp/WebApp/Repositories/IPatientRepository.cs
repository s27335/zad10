using WebApp.Models;

namespace WebApp.Repositories;

public interface IPatientRepository
{
    public Task<Patient?> GetPatient(int idPatient, CancellationToken cancellationToken);
    public Task AddPatient(Patient patient, CancellationToken cancellationToken);
}