namespace SistemaHospitalar.Application.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException(string data) : base(data + " não encontrado(a)")
    {
    }
}