using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Models;

namespace WebApp.Config;

public class PrescriptionMedicamentEfConfig  : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(e => new { e.IdPrescription, e.IdMedicament }).HasName("PresMed_PK");

        builder.HasOne(e => e.Medicament)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdMedicament)
            .HasConstraintName("PresMed_Medicament")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Prescription)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdPrescription)
            .HasConstraintName("PresMed_Prescription")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.Dose);
        builder.Property(e => e.Details).IsRequired();
        

        builder.ToTable("Prescription_Medicament");

        PrescriptionMedicament[] presMeds =
        {
            new PrescriptionMedicament{IdMedicament = 1, IdPrescription = 1, Details = "2x a day"},
            new PrescriptionMedicament{IdMedicament = 1, IdPrescription = 2,Dose = 100,Details = "4x a day"}
        };

        builder.HasData(presMeds);
    }
}