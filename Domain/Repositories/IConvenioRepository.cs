
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Domain.Repositories;
public interface IConvenioRepository : IRepository<Convenio>
{
    Task<Convenio?> GetByIdOrNull(Guid? id);
    Task<Convenio?> GetByCNPJ(string cnpj);
}