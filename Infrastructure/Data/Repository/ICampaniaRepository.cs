using Domain;

namespace Infrastructure.Data.Repository;

public class CampaniaRepository : ICampaniaRepository
{
    public Task AddAsync(Campania campania)
    {
        throw new NotImplementedException();
    }

    public Task AddCampaniaAsync(Campania campania)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCampaniaAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Campania>> GetAllCampaniasAsync()
    {
        return await Task.FromResult(new List<Campania>
        {
            new() { Id = 1, Nombre = "Campaña 1", FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(10) },
            new() { Id = 2, Nombre = "Campaña 2", FechaInicio = DateTime.Now.AddDays(1), FechaFin = DateTime.Now.AddDays(11) },
            new() { Id = 3, Nombre = "Campaña 3", FechaInicio = DateTime.Now.AddDays(2), FechaFin = DateTime.Now.AddDays(12) }
        });
    }

    public Task<Campania?> GetCampaniaByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCampaniaAsync(Campania campania)
    {
        throw new NotImplementedException();
    }
}