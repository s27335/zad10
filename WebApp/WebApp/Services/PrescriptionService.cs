using WebApp.Context;
using WebApp.Models;
using WebApp.Models.DTO;
using WebApp.Repositories;

namespace WebApp.Services;

public class PrescriptionService : IPrescriptionService
{
    private IPrescriptionRepository _prescriptionRepository;
    private IPatientRepository _patientRepository;
    private IMedicamentRepository _medicamentRepository;
    private HospitalDbContext _hospitalDbContext;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository, IPatientRepository patientRepository,
        IMedicamentRepository medicamentRepository, HospitalDbContext hospitalDbContext)
    {
        _prescriptionRepository = prescriptionRepository;
        _patientRepository = patientRepository;
        _medicamentRepository = medicamentRepository;
        _hospitalDbContext = hospitalDbContext;
    }

    public async Task<string> AddPrescription(AddPrescription addPrescription, CancellationToken cancellationToken)
    {
        await using var transaction = await _hospitalDbContext.Database.BeginTransactionAsync(cancellationToken);
        try
        {

            var patient = await _patientRepository.GetPatient(addPrescription.Patient.IdPatient, cancellationToken);
            if (patient == null)
            {
                patient = new Patient()
                {
                    IdPatient = addPrescription.Patient.IdPatient,
                    FirstName = addPrescription.Patient.FirstName,
                    LastName = addPrescription.Patient.LastName,
                    BirthDate = addPrescription.Patient.BirthDate
                };
            }

            if (addPrescription.Medicaments.Count > 10)
            {
                return "To many meds";
            }

            if (addPrescription.DueDate < addPrescription.Date)
            {
                return "Bad date";
            }

            var prescription = new Prescription
            {
                Date = addPrescription.Date,
                DueDate = addPrescription.DueDate,
                IdDoctor = addPrescription.IdDoctor,
                IdPatient = patient.IdPatient,
                PrescriptionMedicaments = new List<PrescriptionMedicament>()
            };

            foreach (var med in addPrescription.Medicaments)
            {
                var medicament = await _medicamentRepository.GetMedicament(med.IdMedicament, cancellationToken);
                if (medicament == null)
                {
                    return "There isn't medicament " + med.Name;
                }

                prescription.PrescriptionMedicaments.Add(new PrescriptionMedicament()
                {
                    IdMedicament = medicament.IdMedicament,
                    Dose = med.Dose,
                    Details = med.Description,
                    IdPrescription = prescription.IdPrescription
                });
            }
            await _prescriptionRepository.AddPrescription(prescription, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            return "Transaction rollback";
        }
        
        return "Prescription added";
    }
}