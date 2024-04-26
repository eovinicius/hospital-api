using SistemaHospitalar.Domain.Validation;

namespace SistemaHospitalar.Domain.Entities;

public class Convenio
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public virtual List<Paciente> Pacientes { get; private set; }
    public bool Ativo { get; private set; }

    public Convenio(string nome, string cnpj)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Cnpj = cnpj;
        Ativo = true;
        Pacientes = [];

        Validate();
    }
    public void Desativar()
    {
        Ativo = false;
    }

    public void Ativar()
    {
        Ativo = true;
    }

    private void Validate()
    {
        var domainValidation = new DomainValidation("convenio");

        domainValidation.NotNullOrEmpty(Nome, nameof(Nome));
        domainValidation.MinLength(Nome, 3, nameof(Nome));
        domainValidation.MaxLength(Nome, 100, nameof(Nome));
        domainValidation.Cnpj(Cnpj, nameof(Cnpj));
        domainValidation.Check();
    }
}