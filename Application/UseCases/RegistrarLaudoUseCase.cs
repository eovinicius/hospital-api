using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Utils;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Exceptions;

namespace SistemaHospitalar.Application.UseCases;

public class RegistrarLaudoUseCase
{
    private readonly ILaudoRepository _laudoRepository;
    private readonly IConsultaRepository _consultaRepository;
    private readonly ILogger<RegistrarLaudoUseCase> _logger;

    public RegistrarLaudoUseCase(ILaudoRepository laudoRepository, IConsultaRepository consultaRepository, ILogger<RegistrarLaudoUseCase> logger)
    {
        _laudoRepository = laudoRepository;
        _consultaRepository = consultaRepository;
        _logger = logger;
    }

    public async Task Handle(RegistrarLaudoInput input)
    {
        _logger.LogInformation("Iniciando cadastro de laudo...");

        var consulta = await _consultaRepository.GetById(input.ConsultaId);


        if (consulta == null)
        {
            throw new NotFoundException("Consulta");
        }

        if (consulta.Laudo != null)
        {
            throw new AlreadyRegisteredException("laudo");
        }

        var image = DocumentUtils.Save(input.ImagemLaudo);

        var laudo = new Laudo(input.Descricao, image, input.ConsultaId);

        await _laudoRepository.Add(laudo);

        consulta.AtualizarStatus(Domain.Enums.EStatusAtendimento.Realizada);

        _logger.LogInformation("Laudo cadastrado com sucesso.");
    }
}