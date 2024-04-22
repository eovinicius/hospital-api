using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class ListarMedicosUseCase
{
    private readonly IMedicoRepository _medicoRepository;
    private readonly ILogger<ListarMedicosUseCase> _logger;

    public ListarMedicosUseCase(IMedicoRepository medicoRepository, ILogger<ListarMedicosUseCase> logger)
    {
        _medicoRepository = medicoRepository;
        _logger = logger;
    }
    public async Task<List<Medico>> Handle()
    {
        _logger.LogInformation("Iniciando listagem de médicos...");
        return await _medicoRepository.GetAll();
    }
}