using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Dtos.output;

public record PacienteDto
(
    string Nome,
    string Documento,
    string? Convenio,
    bool Ativo,
    DateTime CriadoEm
)
{
    public PacienteDto(Paciente paciente) : this(
        paciente.Nome,
        paciente.Documento,
        paciente.Convenio?.Nome,
        paciente.Ativo,
        paciente.CriadoEm)
    { }
}

