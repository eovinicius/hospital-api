namespace SistemaHospitalar.Application.Dtos.input;
public record CadastrarPacienteInput(string Nome, string Documento, IFormFile DocumentFile, string Senha, Guid? ConvenioId);