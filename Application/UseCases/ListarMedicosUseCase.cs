using SistemaHospitalar.Application.Dtos.output;
using SistemaHospitalar.Application.Repositories;

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
    public async Task<List<MedicoOutput>> Handle()
    {
        _logger.LogInformation("Bucando médicos...");
        return await _medicoRepository.GetAll();
    }
}