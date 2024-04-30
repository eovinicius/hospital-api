using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Dtos.output;

public record ConsultaDto
(
    Guid Id,
    DateTime DataHora,
    string Paciente,
    string Medico,
    List<string> Exames,
    decimal Valor,
    string? Laudo
)
{
    public ConsultaDto(Consulta consulta) : this(
        consulta.Id,
        consulta.DataHora,
        consulta.Paciente!.Nome,
        consulta.Medico!.Nome,
        consulta.Exames.Select(e => e.Nome).ToList(),
        consulta.Valor,
        consulta.Laudo?.ConsultaId.ToString()
        )
    {
    }
}