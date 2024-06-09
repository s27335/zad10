using WebApp.Models;

namespace WebApp.Repositories;

public interface IMedicamentRepository
{
    public Task<Medicament?> GetMedicament(int id, CancellationToken cancellationToken);
}