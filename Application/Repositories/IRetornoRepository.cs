using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Repositories;

public interface IRetornoRepository : IRepository<Retorno>
{
    Task<List<Retorno>> GetAll();
}