using WebApp.Models;
using WebApp.Models.DTO;

namespace WebApp.Repositories;

public interface IPrescriptionRepository
{
    public Task<Prescription> AddPrescription(Prescription prescription, CancellationToken cancellationToken);
    public Task<List<Prescription>> GetPrescriptions(int idPatient, CancellationToken cancellationToken);
}