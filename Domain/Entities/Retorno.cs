using SistemaHospitalar.Domain.Enums;
using SistemaHospitalar.Domain.Validation;

namespace SistemaHospitalar.Domain.Entities;

public class Retorno
{
    public Guid Id { get; private set; }
    public DateTime DataHora { get; private set; }
    public decimal Valor { get; private set; }
    public Guid ConsultaId { get; private set; }
    public virtual Consulta? Consulta { get; private set; }
    public EStatusAtendimento Status { get; private set; }

    public Retorno(DateTime dataHora, decimal valor)
    {
        Id = Guid.NewGuid();
        DataHora = dataHora;
        Valor = valor;
        Status = EStatusAtendimento.Agendada;

        Validate();
    }

    private void Validate()
    {
        var domainValidation = new DomainValidation("retorno");
        domainValidation.MinValue(Valor, 0, nameof(Valor));
        domainValidation.Check();
    }
}