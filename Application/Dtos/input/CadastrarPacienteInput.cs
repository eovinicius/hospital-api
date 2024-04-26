namespace SistemaHospitalar.Application.Dtos.input;
public record CadastrarPacienteInput(string Nome, string Documento, IFormFile ImagemDocumento, string Senha, Guid? ConvenioId);