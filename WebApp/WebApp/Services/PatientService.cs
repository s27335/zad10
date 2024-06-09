using WebApp.Models;
using WebApp.Models.DTO;
using WebApp.Repositories;

namespace WebApp.Services;

public class PatientService : IPatientService
{
    private IPatientRepository _patientRepository;
    private IPrescriptionRepository _prescriptionRepository;
    private IDoctorRepository _doctorRepository;

    public PatientService(IPatientRepository patientRepository, IPrescriptionRepository prescriptionRepository,
        IDoctorRepository doctorRepository)
    {
        _patientRepository = patientRepository;
        _prescriptionRepository = prescriptionRepository;
        _doctorRepository = doctorRepository;
    }
    
    public async Task<DTOPatientPrescriptionResponse?> GetPatient(int idPatient, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetPatient(idPatient, cancellationToken);
        if (patient == null)
        {
            return null;
        }

        var prescriptions = await _prescriptionRepository.GetPrescriptions(patient.IdPatient, cancellationToken);

        var response = new DTOPatientPrescriptionResponse()
        {
            Patient = new DTOPatient()
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = patient.BirthDate
            },
            Prescriptions = new List<DTOPrescription>()
        };
        foreach (var pre in prescriptions)
        {
            var doctor = _doctorRepository.GetDoctor(pre.IdDoctor, cancellationToken);
        }
        

        return response;
    }
}