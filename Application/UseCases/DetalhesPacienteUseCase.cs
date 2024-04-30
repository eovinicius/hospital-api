using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Dtos.output;

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
    public async Task<PacienteDto?> Handle(Guid id)
    {
        _logger.LogInformation("Iniciando busca de paciente...");
        var paciente = await _pacienteRepository.GetById(id);
        if (paciente == null)
        {
            throw new NotFoundException("Paciente");
        }

        var pacienteDto = new PacienteDto(paciente);

        _logger.LogInformation("Paciente encontrado com sucesso.");
        return pacienteDto;
    }
}