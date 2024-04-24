using SistemaHospitalar.Domain.Auth;
using SistemaHospitalar.Domain.Validation;

namespace SistemaHospitalar.Domain.Entities;

public class Medico
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Crm { get; private set; }
    public string Especialidade { get; private set; }
    public bool Ativo { get; private set; }
    public virtual List<Consulta> Consultas { get; set; }

    public Medico(string nome, string crm, string especialidade)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Crm = crm;
        Especialidade = especialidade;
        Ativo = true;
        Consultas = [];

        Validate();
    }

    public void Desativar()
    {
        Ativo = false;
    }

    private void Validate()
    {
        DomainValidation.NotNullOrEmpty(Nome, nameof(Nome));
        DomainValidation.MinLength(Nome, 3, nameof(Nome));
        DomainValidation.MaxLength(Nome, 100, nameof(Nome));
        DomainValidation.NotNullOrEmpty(Crm, nameof(Crm));
        DomainValidation.MinLength(Crm, 10, nameof(Crm));
        DomainValidation.MaxLength(Crm, 15, nameof(Crm));
        DomainValidation.NotNullOrEmpty(Especialidade, nameof(Especialidade));
        DomainValidation.MinLength(Especialidade, 3, nameof(Especialidade));
        DomainValidation.MaxLength(Especialidade, 100, nameof(Especialidade));
    }
}