namespace SistemaHospitalar.Application.Dtos.input;

public record MarcarExameInput(Guid PacienteId, Guid MedicoId, DateTime DataExame);