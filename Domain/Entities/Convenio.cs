namespace SistemaHospitalar.Domain.Entities;

public class Convenio
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Cnpj { get; private set; }

    public Convenio(string nome, string cnpj)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Cnpj = cnpj;
    }
}