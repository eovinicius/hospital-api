using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Utils;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Application.Repositories;

namespace SistemaHospitalar.Application.UseCases;

public class RegistrarLaudoUseCase
{
    private readonly ILaudoRepository _laudoRepository;
    private readonly ILogger<RegistrarLaudoUseCase> _logger;

    public RegistrarLaudoUseCase(ILaudoRepository laudoRepository, ILogger<RegistrarLaudoUseCase> logger)
    {
        _laudoRepository = laudoRepository;
        _logger = logger;
    }

    public async Task Handle(RegistrarLaudoInput input)
    {
        _logger.LogInformation("Iniciando cadastro de laudo...");

        var image = DocumentUtils.Save(input.ImagemLaudo);

        var laudo = new Laudo(input.Descricao, image, input.ConsultaId);

        await _laudoRepository.Add(laudo);

        _logger.LogInformation("Laudo cadastrado com sucesso.");
    }
}