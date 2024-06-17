using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Dtos.output;

namespace SistemaHospitalar.Application.UseCases;

public class ListarConsultasByPacienteUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly ILogger<DetalhesConsultaUseCase> _logger;

    public ListarConsultasByPacienteUseCase(IConsultaRepository consultaRepository, ILogger<DetalhesConsultaUseCase> logger)
    {
        _consultaRepository = consultaRepository;
        _logger = logger;
    }

    public async Task<List<ListConsultaOutput>> Handle(Pagination input, Guid id)
    {
        _logger.LogInformation("Buscando detalhes da consulta {id}", id);
        return await _consultaRepository.GetAllConsultaByPaciente(id, input);
    }
}