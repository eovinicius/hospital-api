namespace SistemaHospitalar.Application.Dtos.output;

public record ListConvenioOutput
(
    Guid Id,
    string Nome,
    string Cnpj,
    bool Ativo
);