using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Models;

namespace WebApp.Config;

public class PrescriptionEfConfig : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(e => e.IdPrescription);
        builder.Property(e => e.IdPrescription).UseIdentityColumn();
        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.DueDate).IsRequired();

        builder.HasOne(e => e.Doctor)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.IdDoctor)
            .HasConstraintName("Prescription_Doctor")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Patient)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.IdPatient)
            .HasConstraintName("Prescription_Patient")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Prescription");

        Prescription[] prescriptions =
        {
            new Prescription {IdPrescription = 1, IdDoctor = 1, IdPatient = 1, Date = DateTime.Now, DueDate = DateTime.Now},
            new Prescription {IdPrescription = 2, IdDoctor = 1, IdPatient = 1, Date = DateTime.Now, DueDate = DateTime.Now}
        };
        
        builder.HasData(prescriptions);
    }
}