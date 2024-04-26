using SistemaHospitalar.Domain.Auth;
using SistemaHospitalar.Domain.Validation;

namespace SistemaHospitalar.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Senha { get; private set; }
    public Roles Roles { get; private set; }

    public Usuario(string username, string senha, Roles roles)
    {
        Id = Guid.NewGuid();
        Username = username;
        Senha = senha;
        Roles = roles;

        Validate();
    }

    private void Validate()
    {
        var domainValidation = new DomainValidation("usuario");

        domainValidation.NotNullOrEmpty(Username, nameof(Username));
        domainValidation.NotNullOrEmpty(Senha, nameof(Senha));
        domainValidation.MinLength(Senha, 6, nameof(Senha));
        domainValidation.MaxLength(Senha, 100, nameof(Senha));
        domainValidation.Check();
    }
}