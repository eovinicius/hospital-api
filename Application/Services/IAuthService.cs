using SistemaHospitalar.Domain.Auth;

namespace SistemaHospitalar.Application.Services;
public interface IAuthService
{
    string GenerateToken(Guid userId, Roles roles);
}