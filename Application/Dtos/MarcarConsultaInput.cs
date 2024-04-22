namespace SistemaHospitalar.Application.Dtos;
public record MarcarConsultaInput(Guid MedicoId, Guid PacienteId, DateTime DataConsulta);