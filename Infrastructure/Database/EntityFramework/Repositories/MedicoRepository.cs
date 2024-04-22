using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Repositories;
public class MedicoRepository : IMedicoRepository
{
    private readonly DataContext _context;

    public MedicoRepository(DataContext context)
    {
        _context = context;
    }
    public async Task Add(Medico medico)
    {
        await _context.Medicos.AddAsync(medico);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Medico>> GetAll()
    {
        return await _context.Medicos.ToListAsync();
    }

    public async Task<Medico?> GetByCRM(string crm)
    {
        var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.Crm == crm);
        return medico;
    }

    public async Task<Medico?> GetById(Guid id)
    {
        return await _context.Medicos.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task Update(Medico entity)
    {
        _context.Medicos.Update(entity);
        await _context.SaveChangesAsync();
    }
}