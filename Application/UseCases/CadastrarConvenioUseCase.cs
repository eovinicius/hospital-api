using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.UseCases;
public class CadastrarConvenioUseCase
{
    private readonly IConvenioRepository _convenioRepository;
    private readonly ILogger<CadastrarConvenioUseCase> _logger;
    public CadastrarConvenioUseCase(IConvenioRepository convenioRepository, ILogger<CadastrarConvenioUseCase> logger)
    {
        _convenioRepository = convenioRepository;
        _logger = logger;
    }
    public async Task Handle(CadastrarConvenioInput input)
    {
        _logger.LogInformation("Iniciando cadastro de convênio...");
        var convenioExistente = await _convenioRepository.GetByCNPJ(input.Cnpj);

        if (convenioExistente != null)
        {
            throw new AlreadyRegisteredException("convênio");
        }
        var convenio = new Convenio(input.Nome, input.Cnpj);

        await _convenioRepository.Add(convenio);

        _logger.LogInformation("Convênio cadastrado com sucesso.");
    }
}