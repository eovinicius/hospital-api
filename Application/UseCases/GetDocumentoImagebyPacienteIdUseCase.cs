using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class GetDocumentoImagebyPacienteIdUseCase
{
    private readonly IPacienteRepository _pacienteRepository;

    public GetDocumentoImagebyPacienteIdUseCase(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<string> Handle(Guid pacienteId)
    {
        var paciente = await _pacienteRepository.GetById(pacienteId) ?? throw new NotFoundException("Paciente não encontrado");

        var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
        var filePath = Path.Combine(imagesPath, paciente.ImagemDocumento);

        if (!File.Exists(filePath))
        {
            throw new NotFoundException("Imagem");
        }

        return filePath;
    }
}