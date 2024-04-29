using SistemaHospitalar.Application.Dtos.output;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Repositories;
public interface IPacienteRepository : IRepository<Paciente>
{
    Task<Paciente?> GetByDocumento(string documento);
    Task<List<PacienteOutput>> GetAll(Pagination pagination);
}