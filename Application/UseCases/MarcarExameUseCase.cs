using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;

public class MarcarExameUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IExameRepository _exameRepository;
    private readonly ILogger<MarcarExameUseCase> _logger;

    public MarcarExameUseCase(IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, IExameRepository exameRepository, ILogger<MarcarExameUseCase> logger)
    {
        _pacienteRepository = pacienteRepository;
        _medicoRepository = medicoRepository;
        _exameRepository = exameRepository;
        _logger = logger;
    }
    public async Task Handle(MarcarExameInput input)
    {
        _logger.LogInformation("Iniciando marcação de exame...");
        var paciente = await _pacienteRepository.GetById(input.PacienteId);
        if (paciente == null)
            throw new NotFoundException("paciente");

        var medico = await _medicoRepository.GetById(input.MedicoId);

        if (medico == null)
            throw new NotFoundException("medico");

        var examesDoMedicoNaDataHora = await _exameRepository.ExistsExameMarcado(input.MedicoId, input.DataExame);

        if (examesDoMedicoNaDataHora)
            throw new DatetimeUnavailableException();

        var valorDoExame = 70;

        if (paciente.ConvenioId != null)
            valorDoExame = 0;

        var exame = new Exame(input.Name, input.DataExame, valorDoExame, input.MedicoId, input.PacienteId);

        await _exameRepository.Add(exame);

        _logger.LogInformation("Exame marcado com sucesso.");
    }
}