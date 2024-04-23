namespace SistemaHospitalar.Application.Dtos.input;
public record MarcarConsultaInput(Guid MedicoId, Guid PacienteId, DateTime DataConsulta);