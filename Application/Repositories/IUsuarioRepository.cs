using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Repositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario?> GetByUsername(string username);
    Task<List<Usuario>> GetAll(Pagination pagination);
}