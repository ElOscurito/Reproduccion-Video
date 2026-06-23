using Domain;

namespace Application.Campania.Queries;

public interface ICampaniaGetAll
{
    Task<List<CampaniaGetAllDto>> ExecuteAsync();
}

public class CampaniaGetAll : ICampaniaGetAll
{
    private readonly ICampaniaRepository _campaniaRepository;

    public CampaniaGetAll(ICampaniaRepository campaniaRepository)
    {
        _campaniaRepository = campaniaRepository;
    }

    public async Task<List<CampaniaGetAllDto>> ExecuteAsync()
    {
        var campanias = await _campaniaRepository.GetAllCampaniasAsync();
        return campanias
            .Select(c => new CampaniaGetAllDto(c.Id, c.Nombre.Valor, c.FechaInicio, c.FechaFin))
            .ToList();
    }
}

public record CampaniaGetAllDto(int Id, string Nombre, DateTime FechaInicio, DateTime FechaFin);
