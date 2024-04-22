using SistemaHospitalar.Application.Services;

namespace SistemaHospitalar.Infrastructure.Services;
public class HashService : IHashService
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, 8);
    }
    public bool Compare(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}