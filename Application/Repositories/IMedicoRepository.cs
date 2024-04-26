using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Repositories;
public interface IMedicoRepository : IRepository<Medico>
{
    Task<Medico?> GetByCRM(string crm);
}