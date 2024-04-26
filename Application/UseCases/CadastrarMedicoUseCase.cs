using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Services;
using SistemaHospitalar.Domain.Auth;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.UseCases;
public class CadastrarMedicoUseCase
{
    private readonly IMedicoRepository _medicoRepository;
    private readonly IUsuarioRepository _userRepository;
    private readonly IHashService _hashService;
    private readonly ILogger<CadastrarMedicoUseCase> _logger;

    public CadastrarMedicoUseCase(IMedicoRepository medicoRepository, IHashService hashService, ILogger<CadastrarMedicoUseCase> logger, IUsuarioRepository userRepository)
    {
        _medicoRepository = medicoRepository;
        _hashService = hashService;
        _logger = logger;
        _userRepository = userRepository;
    }
    public async Task<Medico> Handle(CadastrarMedicoInput input)
    {
        _logger.LogInformation("Iniciando cadastro de médico...");
        var medicoExiste = await _medicoRepository.GetByCRM(input.Crm);

        if (medicoExiste != null) throw new AlreadyRegisteredException("medico");

        var hashPassword = _hashService.Hash(input.Senha);

        var medico = new Medico(input.Nome, input.Crm, input.Especialidade);
        var usuario = new Usuario(input.Crm, hashPassword, Roles.Medico);

        await _medicoRepository.Add(medico);
        await _userRepository.Add(usuario);

        _logger.LogInformation("Médico cadastrado com sucesso.");

        return medico;
    }
}