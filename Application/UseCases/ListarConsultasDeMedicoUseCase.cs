using SistemaHospitalar.Application.Dtos.input;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class ListarConsultasDeMedicoUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IMedicoRepository _MedicoRepository;
    private readonly ILogger<ListarConsultasDeMedicoUseCase> _logger;

    public ListarConsultasDeMedicoUseCase(IConsultaRepository consultaRepository, IMedicoRepository medicoRepository, ILogger<ListarConsultasDeMedicoUseCase> logger)
    {
        _consultaRepository = consultaRepository;
        _MedicoRepository = medicoRepository;
        _logger = logger;
    }
    public async Task<List<Consulta>> Execute(ListaCunsultasDeMedicoInput input)
    {
        _logger.LogInformation("Iniciando listagem de consultas de médico...");
        var medico = await _MedicoRepository.GetById(input.MedicoId);

        if (medico == null)
        {
            throw new NotFoundException("medico nao encontrado!");
        }

        return await _consultaRepository.GetConsultasByMedico(medico.Id, input.Status);
    }
}