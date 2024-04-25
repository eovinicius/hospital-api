using SistemaHospitalar.Domain.Exceptions;

namespace SistemaHospitalar.Application.Exceptions;
public class DatetimeUnavailableException : DomainException
{
    public DatetimeUnavailableException() : base("Já existe uma consulta marcada para este médico nesta data e hora") { }
}