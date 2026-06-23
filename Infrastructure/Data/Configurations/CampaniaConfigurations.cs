namespace Infrastructure.Data.Configurations;

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CampaniaConfigurations : IEntityTypeConfiguration<Campania>
{
    public void Configure(EntityTypeBuilder<Campania> builder)
    {
        builder.ToTable("Campanias");
        builder.HasKey(c => c.Id);
        builder
            .Property(c => c.Nombre)
            .HasConversion(n => n.Valor, s => new Nombre(s))
            .HasColumnName("NombreCampania")
            .HasMaxLength(100)
            .IsRequired();
        // builder.OwnsOne(
        //     c => c.Monto,
        //     m =>
        //     {
        //         m.Property(mp => mp.Valor)
        //             .HasConversion()
        //             .HasColumnName("MontoValor")
        //             .HasColumnType("decimal (18,2)")
        //             .IsRequired();
        //         m.Property(mp => mp.Moneda.Codigo)
        //             .HasColumnName("PrecioMoneda")
        //             .HasMaxLength(3)
        //             .IsRequired();
        //     }
        // );
    }
}