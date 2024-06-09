using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Models;

namespace WebApp.Config;

public class DoctorEfConfig  : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
        builder.Property(e => e.IdDoctor).UseIdentityColumn();
        builder.Property(e => e.FirstName).HasMaxLength(200).IsRequired();
        builder.Property(e => e.LastName).HasMaxLength(200).IsRequired();
        builder.Property(e => e.Email).HasMaxLength(200).IsRequired();

        builder.ToTable("Doctor");

        Doctor[] doctors =
        {
            new Doctor {IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jk@gmail.com"}
        };

        builder.HasData(doctors);
    }
}