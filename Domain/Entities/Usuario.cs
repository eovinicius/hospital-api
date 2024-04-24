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
        DomainValidation.NotNullOrEmpty(Username, nameof(Username));
        DomainValidation.MinLength(Username, 3, nameof(Username));
        DomainValidation.MaxLength(Username, 100, nameof(Username));
        DomainValidation.NotNullOrEmpty(Senha, nameof(Senha));
        DomainValidation.MinLength(Senha, 6, nameof(Senha));
        DomainValidation.MaxLength(Senha, 100, nameof(Senha));
    }
}