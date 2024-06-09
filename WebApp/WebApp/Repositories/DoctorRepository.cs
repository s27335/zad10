using WebApp.Context;
using WebApp.Models;

namespace WebApp.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private HospitalDbContext _dbContext;

    public DoctorRepository(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Doctor?> GetDoctor(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Doctors.FindAsync(id, cancellationToken);
    }
}