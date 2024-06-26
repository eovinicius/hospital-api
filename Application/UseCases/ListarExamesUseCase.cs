using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Dtos.output;

namespace SistemaHospitalar.Application.UseCases;

public class ListarExamesUseCase
{
    private readonly IExameRepository _exameRepository;
    private readonly ILogger<ListarExamesUseCase> _logger;

    public ListarExamesUseCase(IExameRepository exameRepository, ILogger<ListarExamesUseCase> logger)
    {
        _exameRepository = exameRepository;
        _logger = logger;
    }

    public async Task<List<ListExameOutput>> Handle(Pagination input)
    {
        _logger.LogInformation("Bucando exames...");
        return await _exameRepository.GetAll(input);
    }
}