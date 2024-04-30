using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Application.Dtos.output;

public record ConvenioDto
(
    Guid Id,
    string Nome,
    string Cnpj,
    bool Ativo,
    List<object> Pacientes
)
{
    public ConvenioDto(Convenio convenio) : this(
        convenio.Id,
        convenio.Nome,
        convenio.Cnpj,
        convenio.Ativo,
        convenio.Pacientes.Select(p => (object)new { p.Id, p.Nome }).ToList()
    )
    { }
}