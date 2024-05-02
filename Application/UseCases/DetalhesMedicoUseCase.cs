using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Dtos.output;

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
    public async Task<MedicoDto?> Handle(Guid id)
    {
        _logger.LogInformation("Buscando médico {id}", id);
        var medico = await _medicoRepository.GetById(id);

        if (medico == null)
        {
            throw new NotFoundException("Médico");
        }

        _logger.LogInformation("Médico {id} encontrado", id);
        return new MedicoDto(medico);

    }
}