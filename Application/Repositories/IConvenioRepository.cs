using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Repositories;
public interface IConvenioRepository : IRepository<Convenio>
{
    Task<Convenio?> GetByIdOrNull(Guid? id);
    Task<Convenio?> GetByCNPJ(string cnpj);
}