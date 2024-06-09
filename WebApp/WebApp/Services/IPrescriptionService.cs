using WebApp.Models;
using WebApp.Models.DTO;

namespace WebApp.Services;

public interface IPrescriptionService
{
    public Task<string> AddPrescription(AddPrescription prescription, CancellationToken cancellationToken);
}