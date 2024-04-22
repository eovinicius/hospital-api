using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.Services;
using SistemaHospitalar.Domain.Auth;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class AutenticarMedicoUseCase
{
    private readonly IMedicoRepository _medicoRepository;
    private readonly IHashService _hashService;
    private readonly IAuthService _tokenService;
    private readonly ILogger<AutenticarMedicoUseCase> _logger;

    public AutenticarMedicoUseCase(IMedicoRepository medicoRepository, IHashService hashService, IAuthService tokenService, ILogger<AutenticarMedicoUseCase> logger)
    {
        _medicoRepository = medicoRepository;
        _hashService = hashService;
        _tokenService = tokenService;
        _logger = logger;
    }
    public async Task<AutenticarMedicoOutput> Handle(AutenticarMedicoInput input)
    {
        _logger.LogInformation("Iniciando autenticação de médico...");

        var medico = await _medicoRepository.GetByCRM(input.Crm);

        if (medico == null) throw new Exception("crm ou senha invalida");

        if (!_hashService.Compare(input.Senha, medico.Senha))
            throw new Exception("crm ou senha invalida");

        var token = _tokenService.GenerateToken(medico.Id, Roles.Medico);

        _logger.LogInformation("Médico autenticado com sucesso.");

        return new AutenticarMedicoOutput(token);
    }
}