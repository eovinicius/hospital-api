using SistemaHospitalar.Application.Dtos.output;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Repositories;

public interface IExameRepository : IRepository<Exame>
{
    Task<bool> ExistsExameMarcado(Guid medicoId, DateTime dataExame);
    Task<List<ListExameOutput>> GetAll(Pagination pagination);
}