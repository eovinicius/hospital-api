using SistemaHospitalar.Domain.Exceptions;

namespace SistemaHospitalar.Application.Exceptions;

public class InvalidCredentialsException : DomainException
{
    public InvalidCredentialsException(string? message) : base(message ?? "Credenciais inválidas")
    {

    }
}