using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;

public class DetalhesConvenioUseCase
{
    private readonly IConvenioRepository _convenioRepository;
    private ILogger<DetalhesConvenioUseCase> _logger;

    public DetalhesConvenioUseCase(IConvenioRepository convenioRepository, ILogger<DetalhesConvenioUseCase> logger)
    {
        _convenioRepository = convenioRepository;
        _logger = logger;
    }

    public async Task<Convenio> Handle(Guid id)
    {
        _logger.LogInformation("Buscando convênio {id}", id);

        var convenio = await _convenioRepository.GetById(id);

        if (convenio == null)
            throw new NotFoundException("Convênio");

        _logger.LogInformation("Convênio {id} encontrado", id);

        return convenio;
    }
}