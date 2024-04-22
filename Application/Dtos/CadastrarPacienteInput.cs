namespace SistemaHospitalar.Application.Dtos;
public record CadastrarPacienteInput(string Nome, string Documento, string Senha, string ImagemDocumento, Guid? ConvenioId);