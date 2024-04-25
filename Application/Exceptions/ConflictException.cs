using SistemaHospitalar.Domain.Exceptions;

namespace SistemaHospitalar.Application.Exceptions;

public class ConflictException : DomainException
{
    public ConflictException(string? message) : base(message ?? "Conflito de dados", StatusCodes.Status409Conflict)
    {
    }
}