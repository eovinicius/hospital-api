using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Enums;
using SistemaHospitalar.Application.Repositories;

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

    public async Task<List<Consulta>> GetAll()
    {
        return await _context.Consultas.AsNoTracking().ToListAsync();
    }

    public async Task<Consulta?> GetById(Guid id)
    {
        return await _context.Consultas.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Consulta>> GetConsultasByMedico(Guid medicoId, EStatusAtendimento? status = null, DateTime? dataInicial = null, DateTime? dataFinal = null)
    {
        IQueryable<Consulta> query = _context.Consultas
            .Where(c => c.MedicoId == medicoId);

        if (status != null)
            query = query.Where(c => c.Status == status);

        if (dataInicial != null)
            query = query.Where(c => c.DataHora >= dataInicial);

        if (dataFinal != null)
            query = query.Where(c => c.DataHora <= dataFinal);

        return await query.ToListAsync();
    }

    public async Task<List<Consulta>> GetConsultasByPaciente(Guid id, EStatusAtendimento? status = null)
    {
        IQueryable<Consulta> query = _context.Consultas
            .Where(c => c.PacienteId == id);

        if (status != null)
            query = query.Where(c => c.Status == status);

        return await query.ToListAsync();
    }


    public Task Update(Consulta consulta)
    {
        _context.Consultas.Update(consulta);
        return _context.SaveChangesAsync();
    }
}