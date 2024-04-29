using SistemaHospitalar.Domain.Enums;

namespace SistemaHospitalar.Application.Dtos.output;

public record ListConsultaOutput(Guid Id, DateTime DataHora, decimal Valor, string? Paciente, string? Medico, object? Exames, EStatusAtendimento Status);