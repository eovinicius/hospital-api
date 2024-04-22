using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Domain.Repositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario?> GetByUsername(string username);
}