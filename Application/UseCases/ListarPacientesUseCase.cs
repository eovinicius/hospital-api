using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Dtos.output;
using SistemaHospitalar.Application.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class ListarPacientesUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly ILogger<ListarPacientesUseCase> _logger;

    public ListarPacientesUseCase(IPacienteRepository pacienteRepository, ILogger<ListarPacientesUseCase> logger)
    {
        _pacienteRepository = pacienteRepository;
        _logger = logger;
    }
    public async Task<List<PacienteOutput>> Handle(Pagination input)
    {
        _logger.LogInformation("Bucando pacientes...");
        return await _pacienteRepository.GetAll(input);
    }
}