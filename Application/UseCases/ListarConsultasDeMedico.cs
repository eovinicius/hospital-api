using SistemaHospitalar.Application.Dtos;
using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Domain.Repositories;
using SQLitePCL;

namespace SistemaHospitalar.Application.UseCases;
public class ListarConsultasDeMedico
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IMedicoRepository _MedicoRepository;
    private readonly ILogger<ListarConsultasDeMedico> _logger;

    public ListarConsultasDeMedico(IConsultaRepository consultaRepository, IMedicoRepository medicoRepository, ILogger<ListarConsultasDeMedico> logger)
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