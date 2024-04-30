using SistemaHospitalar.Application.Dtos.output;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Repositories;

namespace SistemaHospitalar.Application.UseCases;

public class DetalhesExameUseCase
{
    private readonly IExameRepository _exameRepository;
    private readonly ILogger<DetalhesExameUseCase> _logger;

    public DetalhesExameUseCase(IExameRepository exameRepository, ILogger<DetalhesExameUseCase> logger)
    {
        _exameRepository = exameRepository;
        _logger = logger;
    }

    public async Task<ExameDto?> Execute(Guid id)
    {
        var exame = await _exameRepository.GetById(id);

        if (exame == null)
        {
            throw new NotFoundException("Exame");
        }

        _logger.LogInformation("Buscando exame por id: {id}", id);

        return new ExameDto(exame);
    }

}