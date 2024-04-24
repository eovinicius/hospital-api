using SistemaHospitalar.Domain.Validation;

namespace SistemaHospitalar.Domain.Entities;

public class Laudo
{
    public Guid Id { get; private set; }
    public string Descricao { get; private set; }
    public string? Imagem { get; private set; }
    public Guid ConsultaId { get; private set; }
    public virtual Consulta? Consulta { get; private set; }

    public Laudo(string descricao, string? imagem, Guid consultaId)
    {
        Id = Guid.NewGuid();
        Descricao = descricao;
        Imagem = imagem;
        ConsultaId = consultaId;

        Validate();
    }

    private void Validate()
    {
        DomainValidation.NotNullOrEmpty(Descricao, nameof(Descricao));
        DomainValidation.MinLength(Descricao, 3, nameof(Descricao));
        DomainValidation.MaxLength(Descricao, 1000, nameof(Descricao));
    }
}