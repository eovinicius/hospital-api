using SistemaHospitalar.Domain.Auth;
using SistemaHospitalar.Domain.Validation;

namespace SistemaHospitalar.Domain.Entities;

public class Paciente
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Documento { get; private set; }
    public string ImagemDocumento { get; private set; }
    public bool Ativo { get; private set; }
    public Guid? ConvenioId { get; private set; }
    public virtual Convenio? Convenio { get; private set; }
    public virtual List<Consulta> Consultas { get; private set; }

    public Paciente(string nome, string documento, string imagemDocumento, Guid? convenioId)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Documento = documento;
        ImagemDocumento = imagemDocumento;
        ConvenioId = convenioId;
        Ativo = true;
        Consultas = [];

        Validate();
    }

    public void Desativar() => Ativo = false;
    public void Ativar() => Ativo = true;

    private void Validate()
    {
        DomainValidation.NotNullOrEmpty(Nome, nameof(Nome));
        DomainValidation.MinLength(Nome, 3, nameof(Nome));
        DomainValidation.MaxLength(Nome, 100, nameof(Nome));
        DomainValidation.NotNullOrEmpty(Documento, nameof(Documento));
        DomainValidation.NotNull(ImagemDocumento, nameof(ImagemDocumento));
        DomainValidation.Cpf(Documento, nameof(Documento));
    }
}