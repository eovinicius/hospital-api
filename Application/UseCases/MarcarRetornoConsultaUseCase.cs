using SistemaHospitalar.Domain.Enums;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Repositories;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.UseCases;
public class MarcarRetornoConsultaUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly ILogger<MarcarRetornoConsultaUseCase> _logger;

    public MarcarRetornoConsultaUseCase(IConsultaRepository consultaRepository, IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, ILogger<MarcarRetornoConsultaUseCase> logger)
    {
        _consultaRepository = consultaRepository;
        _pacienteRepository = pacienteRepository;
        _medicoRepository = medicoRepository;
        _logger = logger;
    }

    public async Task Execute(Guid consultaId, DateTime dataHora)
    {
        _logger.LogInformation("Iniciando marcação de retorno de consulta...");

        var consulta = await _consultaRepository.GetById(consultaId);

        if (consulta == null)
            throw new NotFoundException("Consulta");

        var paciente = await _pacienteRepository.GetById(consulta.PacienteId);
        var medico = await _medicoRepository.GetById(consulta.MedicoId);

        var TemHotarioMarcado = medico!.Consultas.Any(c => c.DataHora == dataHora);

        if (TemHotarioMarcado)
            throw new DatetimeUnavailableException();

        if (consulta.Status != EStatusConsulta.Realizada)
            throw new Exception("Consulta não realizada para marcar retorno.");

        if (dataHora < DateTime.Now)
            throw new InvalidDateTimeException();

        if (dataHora > consulta.DataHora.AddDays(30))
            throw new Exception("Data de retorno não pode ser superior a 30 dias da data da consulta. Por favor, solicite um novo agendamento.");

        var Retorno = new Consulta(dataHora, 0, paciente!.Id, medico.Id);

        await _consultaRepository.Add(Retorno);

        _logger.LogInformation("Retorno de consulta marcado com sucesso.");
    }
}