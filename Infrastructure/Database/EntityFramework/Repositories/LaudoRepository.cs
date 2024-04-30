using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Repositories;

public class LaudoRepository : ILaudoRepository
{
    private readonly DataContext _dataContext;

    public LaudoRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task Add(Laudo entity)
    {
        await _dataContext.Laudos.AddAsync(entity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<List<Laudo>> GetAll(Pagination pagination)
    {
        return await _dataContext.Laudos
            .Skip((pagination.Page - 1) * pagination.Limit)
            .Take(pagination.Limit)
            .ToListAsync();
    }

    public Task<Laudo?> GetById(Guid id)
    {
        return _dataContext.Laudos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(Laudo entity)
    {
        _dataContext.Laudos.Update(entity);
        await _dataContext.SaveChangesAsync();
    }
}