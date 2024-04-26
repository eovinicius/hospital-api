namespace SistemaHospitalar.Application.Dtos.output;

public record PacienteOutput(Guid Id, string Nome, string Documento, bool Ativo, string? Convenio);