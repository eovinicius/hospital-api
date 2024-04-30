namespace SistemaHospitalar.Application.Dtos.output;

public record ListConsultaOutput(Guid Id, DateTime DataHora, decimal Valor, string? Paciente, string? Medico, List<string>? Exames);