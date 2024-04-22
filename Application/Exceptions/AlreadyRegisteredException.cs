
namespace SistemaHospitalar.Application.Exceptions
{
    public class AlreadyRegisteredException : Exception
    {
        public AlreadyRegisteredException(string data) : base(data + " já cadastrado(a)")
        {
        }
    }
}