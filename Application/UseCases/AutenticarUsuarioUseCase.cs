using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.Services;
using SistemaHospitalar.Domain.Repositories;

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
            throw new Exception("document ou senha invalidos");

        if (!_hashService.Compare(input.Senha, user.Senha))
            throw new Exception("document ou senha invalidos");

        var token = _tokenService.GenerateToken(user.Id, user.Roles);

        _logger.LogInformation($"Usuario {input.Username} autenticado com sucesso");

        return new AutenticarUsuarioOutput(token);
    }
}