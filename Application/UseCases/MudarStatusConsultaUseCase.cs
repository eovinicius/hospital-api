using SistemaHospitalar.Domain.Enums;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class MudarStatusConsultaUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly ILogger<MudarStatusConsultaUseCase> _logger;

    public MudarStatusConsultaUseCase(IConsultaRepository consultaRepository, ILogger<MudarStatusConsultaUseCase> logger)
    {
        _consultaRepository = consultaRepository;
        _logger = logger;
    }
    public async Task Execute(Guid Id, EStatusConsulta novoStatus)
    {
        var consulta = await _consultaRepository.GetById(Id);

        if (consulta == null)
            throw new NotFoundException("Consulta");

        if (novoStatus == EStatusConsulta.Cancelada && consulta.DataHora < DateTime.Now)
            throw new InvalidDateTimeException();

        consulta.AtualizarStatus(novoStatus);
        
        await _consultaRepository.Update(consulta);

        _logger.LogInformation("Status da consulta atualizado com sucesso.");
    }
}