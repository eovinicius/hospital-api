using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class DetalhesPacienteUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly ILogger<DetalhesPacienteUseCase> _logger;

    public DetalhesPacienteUseCase(IPacienteRepository pacienteRepository, ILogger<DetalhesPacienteUseCase> logger)
    {
        _pacienteRepository = pacienteRepository;
        _logger = logger;
    }
    public async Task<Paciente?> Handle(Guid id)
    {
        _logger.LogInformation("Iniciando busca de paciente...");
        return await _pacienteRepository.GetById(id);
    }
}