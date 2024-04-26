namespace SistemaHospitalar.Application.Dtos.output;

public record MedicoOutput(Guid Id, string Nome, string Crm, string Especialidade, bool Ativo);