using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Models;

namespace WebApp.Config;

public class PatientEfConfig  : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(e => e.IdPatient).HasName("Patient_PK");
        builder.Property(e => e.IdPatient).UseIdentityColumn();
        builder.Property(e => e.FirstName).HasMaxLength(200).IsRequired();
        builder.Property(e => e.LastName).HasMaxLength(200).IsRequired();
        builder.Property(e => e.BirthDate).IsRequired();

        builder.ToTable("Patient");

        Patient[] patients =
        {
            new Patient {IdPatient = 1, FirstName = "Piotr", LastName = "Nowak", BirthDate = DateTime.Now}
        };

        builder.HasData(patients);
    }
}