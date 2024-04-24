namespace SistemaHospitalar.Application.Dtos.input;

public record RegistrarLaudoInput(string Descricao, IFormFile ImagemLaudo, Guid ConsultaId);