using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class DesativarPacienteUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly ILogger<DesativarPacienteUseCase> _logger;

    public DesativarPacienteUseCase(IPacienteRepository pacienteRepository, ILogger<DesativarPacienteUseCase> logger)
    {
        _pacienteRepository = pacienteRepository;
        _logger = logger;
    }

    public async Task Execute(Guid pacienteId)
    {
        _logger.LogInformation("Iniciando desativação de paciente...");
        var paciente = await _pacienteRepository.GetById(pacienteId);

        if (paciente is null)
            throw new NotFoundException("Paciente");

        paciente.Desativar();
        await _pacienteRepository.Update(paciente);

        _logger.LogInformation("Paciente desativado com sucesso.");
    }
}