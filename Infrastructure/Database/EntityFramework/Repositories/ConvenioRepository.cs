using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Repositories;
public class ConvenioRepository : IConvenioRepository
{
    private readonly DataContext _context;

    public ConvenioRepository(DataContext context)
    {
        _context = context;
    }
    public async Task Add(Convenio entity)
    {
        await _context.Convenios.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Convenio>> GetAll()
    {
        return await _context.Convenios.ToListAsync();
    }

    public async Task<Convenio?> GetByCNPJ(string cnpj)
    {
        return await _context.Convenios.FirstOrDefaultAsync(c => c.Cnpj == cnpj);
    }

    public async Task<Convenio?> GetById(Guid id)
    {
        return await _context.Convenios.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Convenio?> GetByIdOrNull(Guid? id)
    {
        return await _context.Convenios.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Update(Convenio entity)
    {
        _context.Convenios.Update(entity);
        await _context.SaveChangesAsync();
    }
}