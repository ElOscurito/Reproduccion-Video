using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository;

public class CampaniaRepository : ICampaniaRepository
{
    private readonly ApplicationContext _context;

    public CampaniaRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task AddCampaniaAsync(Campania campania)
    {
        await _context.Campanias.AddAsync(campania);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCampaniaAsync(int id)
    {
        var campania = await _context.Campanias.FindAsync(id);
        if (campania != null)
        {
            _context.Campanias.Remove(campania);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Campania>> GetAllCampaniasAsync()
    {
        return await _context.Campanias.ToListAsync();
    }

    public async Task<Campania?> GetCampaniaByIdAsync(int id)
    {
        return await _context.Campanias.FindAsync(id);
    }

    public async Task UpdateCampaniaAsync(Campania campania)
    {
        _context.Campanias.Update(campania);
        await _context.SaveChangesAsync();
    }
}
