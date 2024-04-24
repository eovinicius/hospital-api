namespace SistemaHospitalar.Application.Dtos.output;

public record ListaMedicosOutput(Guid Id, string Nome, string Crm, string Especialidade, bool Ativo);