using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Dtos.Output;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Services;

namespace SistemaHospitalar.Application.UseCases;
public class AutenticarUsuarioUseCase
{
    private readonly IUsuarioRepository _userRepository;
    private readonly IAuthService _tokenService;
    private readonly IHashService _hashService;
    private readonly ILogger<AutenticarUsuarioUseCase> _logger;

    public AutenticarUsuarioUseCase(IUsuarioRepository userRepository, IAuthService tokenService, IHashService hashService, ILogger<AutenticarUsuarioUseCase> logger)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _hashService = hashService;
        _logger = logger;
    }
    public async Task<AutenticarUsuarioOutput> Handle(AutenticarUsuarioInput input)
    {
        _logger.LogInformation($"Autenticando usuario {input.Username}");
        var user = await _userRepository.GetByUsername(input.Username);

        if (user == null)
            throw new InvalidCredentialsException("usuario ou senha invalidos");

        if (!_hashService.Compare(input.Senha, user.Senha))
            throw new InvalidCredentialsException("usuario ou senha invalidos");

        var token = _tokenService.GenerateToken(user.Id, user.Roles);

        _logger.LogInformation($"Usuario com documento `{input.Username}` autenticado com sucesso");

        return new AutenticarUsuarioOutput(token);
    }
}