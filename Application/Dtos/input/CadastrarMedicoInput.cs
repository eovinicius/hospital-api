namespace SistemaHospitalar.Application.Dtos.input;
public record CadastrarMedicoInput
(
    string Nome,
    string Crm,
    IFormFile ImagemCrm,
    string Senha,
    string Especialidade
);

