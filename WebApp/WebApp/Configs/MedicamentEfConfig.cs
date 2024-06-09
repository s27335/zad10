using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Models;

namespace WebApp.Config;

public class MedicamentEfConfig : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
        builder.Property(e => e.IdMedicament).UseIdentityColumn();
        builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(200).IsRequired();
        builder.Property(e => e.Type).HasMaxLength(200).IsRequired();

        builder.ToTable("Medicament");

        Medicament[] medicaments =
        {
            new Medicament {IdMedicament = 1, Name = "AA", Description = "AA", Type = "A"},
            new Medicament {IdMedicament = 2, Name = "BB", Description = "BB", Type = "B"},
        };

        builder.HasData(medicaments);
    }
}