namespace SistemaHospitalar.Application.Services;
public interface IHashService
{
    string Hash(string password);
    bool Compare(string password, string hash);
}