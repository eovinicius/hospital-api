namespace SistemaHospitalar.Application.Exceptions;
public class InvalidDateTimeException : Exception
{
    public InvalidDateTimeException() : base("Data e hora inválida")
    {
    }
}