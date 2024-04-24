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
    }
}