using SistemaHospitalar.Domain.Validation;

namespace SistemaHospitalar.Domain.Entities;

public class Medico
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Crm { get; private set; }
    public string ImagemCrm { get; private set; }
    public string Especialidade { get; private set; }
    public bool Ativo { get; private set; }
    public virtual List<Consulta> Consultas { get; set; }
    public virtual List<Exame> Exames { get; set; }
    public DateTime CriadoEm { get; private set; }

    public Medico(string nome, string crm, string imagemCrm, string especialidade)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Crm = crm;
        ImagemCrm = imagemCrm;
        Especialidade = especialidade;
        Ativo = true;
        Consultas = [];
        Exames = [];
        CriadoEm = DateTime.Now;

        Validate();
    }

    public void Desativar()
    {
        Ativo = false;
    }

    private void Validate()
    {
        var domainValidation = new DomainValidation("medico");

        domainValidation.NotNullOrEmpty(Nome, nameof(Nome));
        domainValidation.MinLength(Nome, 3, nameof(Nome));
        domainValidation.MaxLength(Nome, 100, nameof(Nome));
        domainValidation.NotNullOrEmpty(Crm, nameof(Crm));
        domainValidation.MinLength(Crm, 10, nameof(Crm));
        domainValidation.MaxLength(Crm, 15, nameof(Crm));
        domainValidation.NotNull(ImagemCrm, nameof(ImagemCrm));
        domainValidation.NotNullOrEmpty(Especialidade, nameof(Especialidade));
        domainValidation.MinLength(Especialidade, 3, nameof(Especialidade));
        domainValidation.MaxLength(Especialidade, 50, nameof(Especialidade));

        domainValidation.Check();
    }
}