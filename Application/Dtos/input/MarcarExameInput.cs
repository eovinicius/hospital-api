namespace SistemaHospitalar.Application.Dtos.input;

public record MarcarExameInput(string Name, Guid PacienteId, Guid MedicoId, DateTime DataExame);