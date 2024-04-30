using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Dtos.output;

public record ExameDto
(
    string Nome,
    DateTime DataHora,
    decimal Valor,
    string Paciente,
    string Medico,
    string ConsultaId
)
{
    public ExameDto(Exame exame) : this(
        exame.Nome,
        exame.DataHora,
        exame.Valor,
        exame.Paciente!.Nome,
        exame.Medico!.Nome,
        exame.Consulta!.Id.ToString()
    )
    { }
}