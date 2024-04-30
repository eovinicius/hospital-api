using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Dtos.output;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Repositories;
public class ConsultaRepository : IConsultaRepository
{
    private readonly DataContext _context;

    public ConsultaRepository(DataContext context)
    {
        _context = context;
    }
    public async Task Add(Consulta consulta)
    {
        await _context.Consultas.AddAsync(consulta);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsConsultaMarcada(Guid medicoId, DateTime dataHora)
    {
        return await _context.Consultas.AnyAsync(c => c.MedicoId == medicoId && c.DataHora == dataHora);
    }

    public async Task<List<ListConsultaOutput>> GetAll(Pagination pagination)
    {
        return await _context.Consultas
        .AsNoTracking()
        .Select(x => new ListConsultaOutput(x.Id, x.DataHora, x.Paciente!.Nome, x.Medico!.Nome, x.Valor, x.Laudo.Id.ToString()))
        .Skip((pagination.Page - 1) * pagination.Limit)
        .Take(pagination.Limit)
        .ToListAsync();
    }

    public async Task<Consulta?> GetById(Guid id)
    {
        return await _context.Consultas
        .Include(x => x.Laudo)
        .Include(x => x.Medico)
        .Include(x => x.Paciente)
        .Include(x => x.Exames)
        .FirstOrDefaultAsync(c => c.Id == id);
    }
    public Task Update(Consulta consulta)
    {
        _context.Consultas.Update(consulta);
        return _context.SaveChangesAsync();
    }
}