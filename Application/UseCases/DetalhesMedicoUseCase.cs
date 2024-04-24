using System.Resources;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;

public class DetalhesMedicoUseCase
{
    private readonly IMedicoRepository _medicoRepository;
    private readonly ILogger<DetalhesMedicoUseCase> _logger;

    public DetalhesMedicoUseCase(IMedicoRepository medicoRepository, ILogger<DetalhesMedicoUseCase> logger)
    {
        _medicoRepository = medicoRepository;
        _logger = logger;
    }
    public async Task<Medico> Handle(Guid id)
    {
        _logger.LogInformation("Buscando médico {id}", id);
        var medico = await _medicoRepository.GetById(id);

        if (medico == null)
        {
            throw new NotFoundException("Médico");
        }

        _logger.LogInformation("Médico {id} encontrado", id);
        return medico;
    }
}