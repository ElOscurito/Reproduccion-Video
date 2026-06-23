namespace Domain;

public class Campania
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}

public interface ICampaniaRepository
{
    Task<Campania?> GetCampaniaByIdAsync(int id);
    Task<List<Campania>> GetAllCampaniasAsync();
    Task AddCampaniaAsync(Campania campania);
    Task UpdateCampaniaAsync(Campania campania);
    Task DeleteCampaniaAsync(int id);
}
