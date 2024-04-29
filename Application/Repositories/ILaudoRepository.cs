using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Repositories;

public interface ILaudoRepository : IRepository<Laudo>
{
    Task<List<Laudo>> GetAll(Pagination pagination);
}