using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Application.Repositories;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DataContext _context;

    public UsuarioRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Add(Usuario entity)
    {
        await _context.Usuarios.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Usuario>> GetAll()
    {
        return await _context.Usuarios.AsNoTracking().ToListAsync();
    }

    public async Task<Usuario?> GetById(Guid id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario?> GetByUsername(string username)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(x => x.Username == username);
    }

    public Task Update(Usuario entity)
    {
        _context.Usuarios.Update(entity);
        return _context.SaveChangesAsync();
    }
}