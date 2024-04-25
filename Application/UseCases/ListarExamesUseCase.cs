using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

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

    public async Task<List<Exame>> Handle()
    {
        _logger.LogInformation("Bucando exames...");
        return await _exameRepository.GetAll();
    }
}