using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Application.Dtos.input;

namespace SistemaHospitalar.Application.UseCases;
public class MarcarConsultaUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IConsultaRepository _consultaRepository;
    private readonly ILogger<MarcarConsultaUseCase> _logger;

    public MarcarConsultaUseCase(IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, IConsultaRepository consultaRepository, ILogger<MarcarConsultaUseCase> logger)
    {
        _pacienteRepository = pacienteRepository;
        _medicoRepository = medicoRepository;
        _consultaRepository = consultaRepository;
        _logger = logger;
    }
    public async Task Handle(MarcarConsultaInput input)
    {
        _logger.LogInformation("Iniciando marcação de consulta...");
        var paciente = await _pacienteRepository.GetById(input.PacienteId);
        if (paciente == null)
            throw new NotFoundException("paciente");

        var medico = await _medicoRepository.GetById(input.MedicoId);

        if (medico == null || medico.Ativo == false)
            throw new NotFoundException("medico");

        var consultasDoMedicoNaDataHora = await _consultaRepository.ExistsConsultaMarcada(input.MedicoId, input.DataConsulta);

        if (consultasDoMedicoNaDataHora)
            throw new DatetimeUnavailableException();

        var valorDaConsulta = 0;

        if (paciente.ConvenioId == null)
            valorDaConsulta = 70;

        var consulta = new Consulta(input.DataConsulta, valorDaConsulta, input.MedicoId, input.PacienteId);

        await _consultaRepository.Add(consulta);

        _logger.LogInformation("Consulta marcada com sucesso.");
    }
}
