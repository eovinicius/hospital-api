using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Domain.Repositories;

public interface IExameRepository : IRepository<Exame>
{
    Task<bool> ExistsExameMarcado(Guid medicoId, DateTime dataExame);
}