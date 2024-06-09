using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private HospitalDbContext _dbContext;

    public PrescriptionRepository(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Prescription> AddPrescription(Prescription prescription, CancellationToken cancellationToken)
    {
        _dbContext.Prescriptions.Add(prescription);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return prescription;
    }

    public async Task<List<Prescription>> GetPrescriptions(int idPatient, CancellationToken cancellationToken)
    {
        return await _dbContext.Prescriptions
            .Where(p => p.IdPatient == idPatient)
            .OrderBy(p => p.DueDate)
            .ToListAsync(cancellationToken);
    }
}