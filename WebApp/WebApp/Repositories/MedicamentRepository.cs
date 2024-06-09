using WebApp.Context;
using WebApp.Models;

namespace WebApp.Repositories;

public class MedicamentRepository : IMedicamentRepository
{
    private HospitalDbContext _dbContext;

    public MedicamentRepository(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Medicament?> GetMedicament(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Medicaments.FindAsync(id, cancellationToken);
    }
}