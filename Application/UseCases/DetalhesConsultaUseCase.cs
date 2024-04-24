using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;

public class DetalhesConsultaUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    private ILogger<DetalhesConsultaUseCase> _logger;

    public DetalhesConsultaUseCase(IConsultaRepository consultaRepository, ILogger<DetalhesConsultaUseCase> logger)
    {
        _consultaRepository = consultaRepository;
        _logger = logger;
    }

    public async Task Handle(Guid id)
    {
        _logger.LogInformation("Buscando detalhes da consulta {id}", id);

        var consulta = await _consultaRepository.GetById(id);

        if (consulta == null)
            throw new NotFoundException("Consulta");

        _logger.LogInformation("Detalhes da consulta {id} encontrados", id);
    }
}