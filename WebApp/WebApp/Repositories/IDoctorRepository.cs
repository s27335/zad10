using WebApp.Models;

namespace WebApp.Repositories;

public interface IDoctorRepository
{
    public Task<Doctor?> GetDoctor(int id, CancellationToken cancellationToken);

}