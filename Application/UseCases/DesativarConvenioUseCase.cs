using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Repositories;

namespace SistemaHospitalar.Application.UseCases;

public class DesativarConvenioUseCase
{
    private readonly IConvenioRepository _convenioRepository;
    private ILogger<DesativarConvenioUseCase> _logger;

    public DesativarConvenioUseCase(IConvenioRepository convenioRepository, ILogger<DesativarConvenioUseCase> logger)
    {
        _convenioRepository = convenioRepository;
        _logger = logger;
    }
    public async Task Handle(Guid id)
    {
        _logger.LogInformation("Desativando convênio {id}", id);

        var convenio = await _convenioRepository.GetById(id);

        if (convenio == null)
            throw new NotFoundException("Convênio");

        if (convenio.Ativo == false)
            throw new ConflictException("Convênio já está desativado.");

        convenio.Desativar();
        await _convenioRepository.Update(convenio);

        _logger.LogInformation("Convênio {id} desativado", id);
    }
}