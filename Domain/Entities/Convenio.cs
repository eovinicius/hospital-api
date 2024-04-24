using SistemaHospitalar.Domain.Validation;

namespace SistemaHospitalar.Domain.Entities;

public class Convenio
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public bool Ativo { get; private set; }

    public Convenio(string nome, string cnpj)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Cnpj = cnpj;
        Ativo = true;

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
        DomainValidation.NotNullOrEmpty(Nome, nameof(Nome));
        DomainValidation.MinLength(Nome, 3, nameof(Nome));
        DomainValidation.MaxLength(Nome, 100, nameof(Nome));
        DomainValidation.Cnpj(Cnpj, nameof(Cnpj));
    }
}