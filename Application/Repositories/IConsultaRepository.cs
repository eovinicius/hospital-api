using SistemaHospitalar.Application.Dtos.output;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Repositories;
public interface IConsultaRepository : IRepository<Consulta>
{
    Task<bool> ExistsConsultaMarcada(Guid medicoId, DateTime dataHora);
    Task<List<ListConsultaOutput>> GetAll(Pagination pagination);
    Task<List<ListConsultaOutput>> GetAllConsultaByPaciente(Guid pacienteId, Pagination pagination);
}
