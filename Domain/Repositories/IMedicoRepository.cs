using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Domain.Repositories;
public interface IMedicoRepository : IRepository<Medico>
{
    Task<Medico?> GetByCRM(string crm);
}