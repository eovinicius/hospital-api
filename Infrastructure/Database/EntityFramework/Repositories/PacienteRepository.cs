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

    public async Task<List<PacienteOutput>> GetAll()
    {
        return await _context.Pacientes
        .AsNoTracking()
        .Select(p => new PacienteOutput(p.Id, p.Nome, p.Documento, p.Ativo, p.Convenio.Nome))
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

    Task<List<Paciente>> IRepository<Paciente>.GetAll()
    {
        throw new NotImplementedException();
    }
}