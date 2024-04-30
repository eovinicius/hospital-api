using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Dtos.output;

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

    public async Task<List<ListExameOutput>> GetAll(Pagination pagination)
    {
        return await _context.Exames
        .AsNoTracking()
        .Skip((pagination.Page - 1) * pagination.Limit)
        .Take(pagination.Limit)
        .Select(x => new ListExameOutput(x.Id, x.Nome, x.DataHora, x.Valor, x.Paciente!.Nome, x.Medico!.Nome, x.ConsultaId.ToString()))
        .ToListAsync();
    }

    public async Task<Exame?> GetById(Guid id)
    {
        return await _context.Exames
        .Include(x => x.Paciente)
        .Include(x => x.Medico)
        .Include(x => x.Consulta)
        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(Exame entity)
    {
        _context.Exames.Update(entity);
        await _context.SaveChangesAsync();
    }
}