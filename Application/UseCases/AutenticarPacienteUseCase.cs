using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.Services;
using SistemaHospitalar.Domain.Auth;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class AutenticarPacienteUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IAuthService _tokenService;
    private readonly IHashService _hashService;
    private readonly ILogger<AutenticarPacienteUseCase> _logger;

    public AutenticarPacienteUseCase(IPacienteRepository pacienteRepository, IAuthService tokenService, IHashService hashService, ILogger<AutenticarPacienteUseCase> logger)
    {
        _pacienteRepository = pacienteRepository;
        _tokenService = tokenService;
        _hashService = hashService;
        _logger = logger;
    }
    public async Task<AutenticarPacienteOutput> Handle(AutenticarPacienteInput input)
    {
        var paciente = await _pacienteRepository.GetByDocumento(input.Documento);

        if (paciente == null)
            throw new Exception("document ou senha invalidos");

        if (!_hashService.Compare(input.Senha, paciente.Senha))
            throw new Exception("document ou senha invalidos");

        var token = _tokenService.GenerateToken(paciente.Id, Roles.Paciente);

        return new AutenticarPacienteOutput(token);
    }
}