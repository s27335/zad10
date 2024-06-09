using WebApp.Context;
using WebApp.Models;

namespace WebApp.Repositories;

public class PatientRepository : IPatientRepository
{
    private HospitalDbContext _dbContext;

    public PatientRepository(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Patient?> GetPatient(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Patients.FindAsync(id, cancellationToken);
    }

    public async Task AddPatient(Patient patient, CancellationToken cancellationToken)
    {
        _dbContext.Add(patient);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}