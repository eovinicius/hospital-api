namespace SistemaHospitalar.Application.Dtos.output;

public record ListPacienteOutput(Guid Id, string Nome, string Documento, bool Ativo, string? Convenio);