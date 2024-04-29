using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Application.Dtos.output;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Application.Repositories;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Repositories;
public class PacienteRepository : IPacienteRepository
{
    private readonly DataContext _context;

    public PacienteRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Add(Paciente paciente)
    {
        await _context.Pacientes.AddAsync(paciente);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ListPacienteOutput>> GetAll(Pagination pagination)
    {
        return await _context.Pacientes
        .AsNoTracking()
        .Select(p => new ListPacienteOutput(p.Id, p.Nome, p.Documento, p.Ativo, p.Convenio!.Nome))
        .Skip((pagination.Page - 1) * pagination.Limit)
        .Take(pagination.Limit)
        .ToListAsync();
    }

    public async Task<Paciente?> GetByDocumento(string documento)
    {
        return await _context.Pacientes.FirstOrDefaultAsync(p => p.Documento == documento);
    }

    public async Task<Paciente?> GetById(Guid id)
    {
        return await _context.Pacientes
        .Include(p => p.Consultas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task Update(Paciente paciente)
    {
        _context.Pacientes.Update(paciente);
        return _context.SaveChangesAsync();
    }
}