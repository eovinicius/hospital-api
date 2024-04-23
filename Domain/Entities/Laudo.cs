namespace SistemaHospitalar.Domain.Entities;

public class Laudo
{
    public Guid Id { get; private set; }
    public string Descricao { get; private set; }
    public Guid ExameId { get; private set; }
    public virtual Exame? Exame { get; private set; }

    public Laudo(string descricao, Guid exameId)
    {
        Id = Guid.NewGuid();
        Descricao = descricao;
        ExameId = exameId;
    }
}