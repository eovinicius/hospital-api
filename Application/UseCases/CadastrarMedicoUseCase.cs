using BCrypt.Net;
using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Services;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class CadastrarMedicoUseCase
{
    private readonly IMedicoRepository _medicoRepository;
    private readonly IHashService _hashService;
    private readonly ILogger<CadastrarMedicoUseCase> _logger;

    public CadastrarMedicoUseCase(IMedicoRepository medicoRepository, IHashService hashService, ILogger<CadastrarMedicoUseCase> logger)
    {
        _medicoRepository = medicoRepository;
        _hashService = hashService;
        _logger = logger;
    }
    public async Task<Medico> Handle(CadastrarMedicoInput input)
    {
        _logger.LogInformation("Iniciando cadastro de médico...");
        var medicoExiste = await _medicoRepository.GetByCRM(input.Crm);

        if (medicoExiste != null) throw new AlreadyRegisteredException("medico");

        var hashPassword = _hashService.Hash(input.Senha);

        var medico = new Medico(input.Nome, input.Crm, hashPassword, input.Especialidade);

        await _medicoRepository.Add(medico);

        _logger.LogInformation("Médico cadastrado com sucesso.");

        return medico;
    }
}