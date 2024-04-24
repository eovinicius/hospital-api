using System.ComponentModel.DataAnnotations;

namespace SistemaHospitalar.Application.Dtos.input;
public record CadastrarMedicoInput(string Nome, string Crm, [MinLength(6)] string Senha, string Especialidade);

