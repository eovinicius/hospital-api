using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Dtos.output;

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

    public async Task<List<ListMedicoOutput>> GetAll(Pagination pagination)
    {
        return await _context.Medicos
        .AsNoTracking()
        .Select(m => new ListMedicoOutput(m.Id, m.Nome, m.Crm, m.Especialidade, m.Ativo))
        .Skip((pagination.Page - 1) * pagination.Limit)
        .Take(pagination.Limit)
        .ToListAsync();
    }

    public async Task<Medico?> GetByCRM(string crm)
    {
        return await _context.Medicos
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Crm == crm);

    }

    public async Task<Medico?> GetById(Guid id)
    {
        return await _context.Medicos
        .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task Update(Medico entity)
    {
        _context.Medicos.Update(entity);
        await _context.SaveChangesAsync();
    }
}