namespace SistemaHospitalar.Application.Dtos.output;

public record ListPacienteOutput(Guid Id, string Nome, string Documento, string? Convenio, bool Ativo);