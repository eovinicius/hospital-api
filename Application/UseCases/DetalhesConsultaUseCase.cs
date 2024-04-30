using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Dtos.output;

namespace SistemaHospitalar.Application.UseCases;

public class DetalhesConsultaUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly ILogger<DetalhesConsultaUseCase> _logger;

    public DetalhesConsultaUseCase(IConsultaRepository consultaRepository, ILogger<DetalhesConsultaUseCase> logger)
    {
        _consultaRepository = consultaRepository;
        _logger = logger;
    }

    public async Task<ConsultaDto> Handle(Guid id)
    {
        _logger.LogInformation("Buscando detalhes da consulta {id}", id);

        var consulta = await _consultaRepository.GetById(id);

        if (consulta == null)
            throw new NotFoundException("Consulta");

        _logger.LogInformation("Detalhes da consulta {id} encontrados", id);

        return new ConsultaDto(consulta);
    }
}