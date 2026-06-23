namespace Infrastructure.Data.Configurations;

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CampaniaConfigurations : IEntityTypeConfiguration<Campania>
{
    public void Configure(EntityTypeBuilder<Campania> builder)
    {
        builder.ToTable("Campanias");
        builder.HasKey(d => d.Id);
        builder
            .Property(d => d.Nombre)
            .HasConversion(n => n.Valor, s => new Nombre(s))
            .HasColumnName("NombreCampania")
            .HasMaxLength(100)
            .IsRequired();
    }
}