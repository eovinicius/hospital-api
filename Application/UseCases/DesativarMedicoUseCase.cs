using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;

public class DesativarMedicoUseCase
{
    private readonly IMedicoRepository _medicoRepository;
    private ILogger<DesativarMedicoUseCase> _logger;

    public DesativarMedicoUseCase(IMedicoRepository medicoRepository, ILogger<DesativarMedicoUseCase> logger)
    {
        _medicoRepository = medicoRepository;
        _logger = logger;
    }

    public async Task Handle(Guid id)
    {
        _logger.LogInformation("Desativando médico {id}", id);

        var medico = await _medicoRepository.GetById(id);

        if (medico == null)
            throw new NotFoundException("Médico");
        
        if (medico.Ativo == false)
            throw new ConflictException("Médico já está desativado.");

        medico.Desativar();
        await _medicoRepository.Update(medico);

        _logger.LogInformation("Médico {id} desativado", id);
    }
}