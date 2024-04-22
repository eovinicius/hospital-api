using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Domain.Repositories;
public interface IPacienteRepository : IRepository<Paciente>
{
    Task<Paciente?> GetByDocumento(string documento);
}