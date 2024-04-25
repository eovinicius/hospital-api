using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Services;
using SistemaHospitalar.Application.Utils;
using SistemaHospitalar.Domain.Auth;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class CadastrarPacienteUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConvenioRepository _convenioRepository;
    private readonly IUsuarioRepository _userRepository;
    private readonly IHashService _hashService;
    private readonly ILogger<AtualizarConsultaUseCase> _logger;

    public CadastrarPacienteUseCase(IPacienteRepository pacienteRepository, IConvenioRepository convenioRepository, IHashService hashService, ILogger<AtualizarConsultaUseCase> logger, IUsuarioRepository userRepository)
    {
        _pacienteRepository = pacienteRepository;
        _convenioRepository = convenioRepository;
        _hashService = hashService;
        _logger = logger;
        _userRepository = userRepository;
    }

    public async Task Handle(CadastrarPacienteInput input)
    {
        _logger.LogInformation("Iniciando cadastro de paciente...");
        var pacienteExistente = await _pacienteRepository.GetByDocumento(input.Documento);

        if (pacienteExistente != null)
            throw new AlreadyRegisteredException("paciente");

        if (input.ConvenioId != null)
        {
            var convenio = await _convenioRepository.GetByIdOrNull(input.ConvenioId);

            if (convenio == null || convenio.Ativo == false)
                throw new NotFoundException("convênio");
        }
        var hashPassword = _hashService.Hash(input.Senha);

        var documentPath = DocumentUtils.Save(input.DocumentFile);

        var paciente = new Paciente(input.Nome, input.Documento, documentPath, input.ConvenioId);
        var usuario = new Usuario(input.Documento, hashPassword, Roles.Paciente);

        await _userRepository.Add(usuario);
        await _pacienteRepository.Add(paciente);

        _logger.LogInformation("Paciente cadastrado com sucesso.");
    }
}
