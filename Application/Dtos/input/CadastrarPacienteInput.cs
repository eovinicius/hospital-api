namespace SistemaHospitalar.Application.Dtos.input;
public record CadastrarPacienteInput(string Nome, string Documento, string Senha, IFormFile ImagemDocumento, Guid? ConvenioId);