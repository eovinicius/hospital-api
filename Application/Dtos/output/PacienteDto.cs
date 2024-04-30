using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Dtos.output;

public record PacienteDto
(
    Guid Id,
    string Nome,
    string Documento,
    string? Convenio,
    bool Ativo,
    DateTime CriadoEm
)
{
    public PacienteDto(Paciente paciente) : this(
        paciente.Id,
        paciente.Nome,
        paciente.Documento,
        paciente.Convenio?.Nome,
        paciente.Ativo,
        paciente.CriadoEm)
    { }
}

