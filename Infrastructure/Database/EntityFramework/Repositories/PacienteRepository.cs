using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

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

    public async Task<List<Paciente>> GetAll()
    {
        return await _context.Pacientes.Include(x => x.Convenio).ToListAsync();
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