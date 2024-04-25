using SistemaHospitalar.Domain.Exceptions;

namespace SistemaHospitalar.Application.Exceptions;
public class InvalidDateTimeException : DomainException
{
    public InvalidDateTimeException() : base("Data e hora inválida")
    {
    }
}