namespace SistemaHospitalar.Application.Exceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException(string? message) : base(message ?? "Credenciais inválidas")
    {
    }
}