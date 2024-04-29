using SistemaHospitalar.Application.Dtos.output;
using SistemaHospitalar.Application.Repositories;

namespace SistemaHospitalar.Application.UseCases;

public class ListarConsultasUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly ILogger<ListarConveniosUseCase> _logger;

    public ListarConsultasUseCase(IConsultaRepository consultaRepository, ILogger<ListarConveniosUseCase> logger)
    {
        _consultaRepository = consultaRepository;
        _logger = logger;
    }
    public async Task<List<ConsultaOutput>> Handle()
    {
        _logger.LogInformation("Iniciando listagem de convênios...");
        return await _consultaRepository.GetAll();
    }
}