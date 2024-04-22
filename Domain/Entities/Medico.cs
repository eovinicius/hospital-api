using SistemaHospitalar.Domain.Auth;

namespace SistemaHospitalar.Domain.Entities;

public class Medico
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Crm { get; private set; }
    public string Especialidade { get; private set; }
    public bool Ativo { get; private set; }
    public virtual List<Consulta> Consultas { get; set; }
    public Roles Roles { get; private set; }

    public Medico(string nome, string crm, string especialidade)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Crm = crm;
        Especialidade = especialidade;
        Ativo = true;
        Consultas = [];
        Roles = Roles.Medico;
    }
}