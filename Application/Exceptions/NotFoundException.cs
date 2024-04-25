using SistemaHospitalar.Domain.Exceptions;

namespace SistemaHospitalar.Application.Exceptions;
public class NotFoundException : DomainException
{
    public NotFoundException(string data) : base(data + " não encontrado(a)", StatusCodes.Status404NotFound)
    {
    }
}