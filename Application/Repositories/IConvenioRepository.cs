using SistemaHospitalar.Application.Dtos.output;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Repositories;
public interface IConvenioRepository : IRepository<Convenio>
{
    Task<Convenio?> GetByIdOrNull(Guid? id);
    Task<Convenio?> GetByCNPJ(string cnpj);
    Task<List<ListConvenioOutput>> GetAll(Pagination pagination);
}