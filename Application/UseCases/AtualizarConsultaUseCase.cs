using SistemaHospitalar.Application.Exceptions;
using SistemaHospitalar.Domain.Repositories;

namespace SistemaHospitalar.Application.UseCases;
public class AtualizarConsultaUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly ILogger<AtualizarConsultaUseCase> _logger;

    public AtualizarConsultaUseCase(IConsultaRepository consultaRepository, ILogger<AtualizarConsultaUseCase> logger)
    {
        _consultaRepository = consultaRepository;
        _logger = logger;
    }
    public async Task Execute(Guid Id, DateTime novaDataHora)
    {
        _logger.LogInformation("Iniciando atualização de consulta...");

        var consulta = await _consultaRepository.GetById(Id);

        if (consulta == null)
            throw new NotFoundException("Consulta");

        if (novaDataHora < DateTime.Now)
            throw new InvalidDateTimeException();

        if (await _consultaRepository.ExistsConsultaMarcada(consulta.MedicoId, novaDataHora))
            throw new DatetimeUnavailableException();

        consulta.AtualizarDataHora(novaDataHora);

        await _consultaRepository.Update(consulta);

        _logger.LogInformation("Consulta atualizada com sucesso.");
    }
}