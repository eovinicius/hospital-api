using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class ListarConsultasDePaciente
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IPacienteRepository _PacienteRepository;
    private readonly ILogger<ListarConsultasDePaciente> _logger;

    public ListarConsultasDePaciente(IConsultaRepository consultaRepository, IPacienteRepository pacienteRepository, ILogger<ListarConsultasDePaciente> logger)
    {
        _consultaRepository = consultaRepository;
        _PacienteRepository = pacienteRepository;
        _logger = logger;
    }

    public async Task<List<Consulta>> Execute(ListarConsultasDePacienteInput input)
    {
        _logger.LogInformation("Iniciando listagem de consultas de paciente...");
        var paciente = await _PacienteRepository.GetById(input.PacienteId);

        if (paciente == null)
        {
            throw new NotFoundException("paciente nao encontrado!");
        }

        return await _consultaRepository.GetConsultasByPaciente(paciente.Id, input.Status);
    }
}