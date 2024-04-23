using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Repositories;

public class ExameRepository : IExameRepository
{

    private readonly DataContext _context;

    public ExameRepository(DataContext context)
    {
        _context = context;
    }
    public async Task Add(Exame entity)
    {
        await _context.Exames.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsExameMarcado(Guid medicoId, DateTime dataExame)
    {
        return await _context.Exames.AnyAsync(e => e.MedicoId == medicoId && e.DataHora == dataExame);
    }

    public async Task<List<Exame>> GetAll()
    {
        return await _context.Exames.ToListAsync();
    }

    public async Task<Exame?> GetById(Guid id)
    {
        return await _context.Exames.FindAsync(id);
    }

    public async Task Update(Exame entity)
    {
        _context.Exames.Update(entity);
        await _context.SaveChangesAsync();
    }
}