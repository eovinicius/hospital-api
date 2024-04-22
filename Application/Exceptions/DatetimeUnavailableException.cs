namespace SistemaHospitalar.Application.Exceptions;
public class DatetimeUnavailableException : Exception
{
    public DatetimeUnavailableException() : base("Já existe uma consulta marcada para este médico nesta data e hora")
    {
    }
}