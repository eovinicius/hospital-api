using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Domain.Repositories;
public interface IConsultaRepository : IRepository<Consulta>
{
    Task<List<Consulta>> GetConsultasByPaciente(Guid id, EStatusConsulta? status = null);
    Task<List<Consulta>> GetConsultasByMedico(Guid medicoId, EStatusConsulta? status = null, DateTime? dataInicial = null, DateTime? dataFinal = null);

    Task<bool> ExistsConsultaMarcada(Guid medicoId, DateTime dataHora);
}
