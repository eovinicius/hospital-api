using SistemaHospitalar.Domain.Auth;

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
    public Roles Roles { get; private set; }

    public Paciente(string nome, string documento, string imagemDocumento, Guid? convenioId)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Documento = documento;
        ImagemDocumento = imagemDocumento;
        ConvenioId = convenioId;
        Ativo = true;
        Consultas = [];
        Roles = Roles.Paciente;
    }

    public void Desativar()
    {
        Ativo = false;
    }
}