namespace SistemaHospitalar.Application.Dtos.output;

public record ListConsultaOutput(Guid Id, DateTime DataHora, string? Paciente, string? Medico, decimal Valor);