using System.ComponentModel.DataAnnotations.Schema;
using Domain.Comunes;

namespace Domain;

public class Campania : Entidad
{
    public Nombre Nombre { get; set; } = new Nombre(string.Empty);
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    //public Dinero Monto { get; set; } = new Dinero(0, Moneda.USD);
}


public record Nombre(string Valor);

public record Dinero(decimal Valor, Moneda Moneda);

public record Moneda
{
    public static readonly Moneda USD = new Moneda("USD");
    public static readonly Moneda EUR = new Moneda("EUR");

    public string Codigo { get; set; }

    public Moneda(string codigo)
    {
        Codigo = codigo;
    }
}

public interface ICampaniaRepository
{
    Task<Campania?> GetCampaniaByIdAsync(int id);
    Task<List<Campania>> GetAllCampaniasAsync();
    Task AddCampaniaAsync(Campania campania);
    Task UpdateCampaniaAsync(Campania campania);
    Task DeleteCampaniaAsync(int id);
}
