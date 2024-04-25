
using SistemaHospitalar.Domain.Exceptions;

namespace SistemaHospitalar.Application.Exceptions
{
    public class AlreadyRegisteredException : DomainException
    {
        public AlreadyRegisteredException(string data) : base(data + " já cadastrado(a)")
        {
        }
    }
}