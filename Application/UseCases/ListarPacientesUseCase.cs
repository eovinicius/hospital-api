using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

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
    public async Task<List<Paciente>> Handle()
    {
        _logger.LogInformation("Iniciando listagem de pacientes...");
        return await _pacienteRepository.GetAll();
    }
}