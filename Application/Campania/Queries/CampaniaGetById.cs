using Domain;

namespace Application.Campania.Queries;

public interface ICampaniaGetById

{
    Task<CampaniaGetByIdDto?> ExecuteAsync(int id);
}

public class CampaniaGetById : ICampaniaGetById
{
    private readonly ICampaniaRepository _campaniaRepository;

    public CampaniaGetById(ICampaniaRepository campaniaRepository)
    {
        _campaniaRepository = campaniaRepository;
    }

    public async Task<CampaniaGetByIdDto?> ExecuteAsync(int id)
    {
        var campania = await _campaniaRepository.GetCampaniaByIdAsync(id);
        if (campania == null)
        {
            return null;
        }
        return new CampaniaGetByIdDto(campania.Id, campania.Nombre.Valor, campania.FechaInicio, campania.FechaFin);
    }
}

public record CampaniaGetByIdDto(int Id, string Nombre, DateTime FechaInicio, DateTime FechaFin);
