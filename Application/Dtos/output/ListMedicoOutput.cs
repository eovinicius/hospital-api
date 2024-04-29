namespace SistemaHospitalar.Application.Dtos.output;

public record ListMedicoOutput(Guid Id, string Nome, string Crm, string Especialidade, bool Ativo);