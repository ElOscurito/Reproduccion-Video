using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Campania
{
    public int Id { get; set; }
    public Nombre Nombre { get; set; } = new Nombre(string.Empty);
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}

[NotMapped]
public record Nombre(string Valor);

public interface ICampaniaRepository
{
    Task<Campania?> GetCampaniaByIdAsync(int id);
    Task<List<Campania>> GetAllCampaniasAsync();
    Task AddCampaniaAsync(Campania campania);
    Task UpdateCampaniaAsync(Campania campania);
    Task DeleteCampaniaAsync(int id);
}
