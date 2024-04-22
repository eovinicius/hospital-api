using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Services;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class CadastrarPacienteUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConvenioRepository _convenioRepository;
    private readonly IHashService _hashService;
    private readonly ILogger<AtualizarConsultaUseCase> _logger;


    public CadastrarPacienteUseCase(IPacienteRepository pacienteRepository, IConvenioRepository convenioRepository, IHashService hashService, ILogger<AtualizarConsultaUseCase> logger)
    {
        _pacienteRepository = pacienteRepository;
        _convenioRepository = convenioRepository;
        _hashService = hashService;
        _logger = logger;
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

            if (convenio == null)
                throw new NotFoundException("convênio");
        }

        var hashPassword = _hashService.Hash(input.Senha);

        var paciente = new Paciente(input.Nome, input.Documento, hashPassword, input.ImagemDocumento, input.ConvenioId);

        await _pacienteRepository.Add(paciente);

        _logger.LogInformation("Paciente cadastrado com sucesso.");
    }
}
