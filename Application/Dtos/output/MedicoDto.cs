using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Dtos.output;

public record MedicoDto
(
    string Nome,
    string Crm,
    string Especialidade,
    bool Ativo,
    DateTime CriadoEm
)
{
    public MedicoDto(Medico medico) : this(
        medico.Nome,
        medico.Crm,
        medico.Especialidade,
        medico.Ativo,
        medico.CriadoEm)
    { }
}