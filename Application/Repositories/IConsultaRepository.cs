using SistemaHospitalar.Application.Dtos.output;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Application.Repositories;
public interface IConsultaRepository : IRepository<Consulta>
{
    Task<List<Consulta>> GetConsultasByPaciente(Guid id, EStatusAtendimento? status = null);
    Task<List<Consulta>> GetConsultasByMedico(Guid medicoId, EStatusAtendimento? status = null, DateTime? dataInicial = null, DateTime? dataFinal = null);
    Task<bool> ExistsConsultaMarcada(Guid medicoId, DateTime dataHora);
    Task<List<ConsultaOutput>> GetAll(Pagination pagination);
}
