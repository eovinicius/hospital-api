using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Dtos.output;

namespace SistemaHospitalar.Application.UseCases;
public class ListarConveniosUseCase
{
    private readonly IConvenioRepository _convenioRepository;
    private readonly ILogger<ListarConveniosUseCase> _logger;

    public ListarConveniosUseCase(IConvenioRepository convenioRepository, ILogger<ListarConveniosUseCase> logger)
    {
        _convenioRepository = convenioRepository;
        _logger = logger;
    }
    public async Task<List<ListConvenioOutput>> Handle(Pagination input)
    {
        _logger.LogInformation("Iniciando listagem de convênios...");
        return await _convenioRepository.GetAll(input);
    }
}