using SistemaHospitalar.Domain.Auth;

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
    }
}