namespace SistemaHospitalar.Application.Dtos.output;

public record ListExameOutput
(
    Guid Id,
    string Nome,
    DateTime DataHora,
    decimal Valor,
    string Paciente,
    string Medico,
    string ConsultaId
);