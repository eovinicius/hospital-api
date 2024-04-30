using SistemaHospitalar.Application.Repositories;
using SistemaHospitalar.Application.Services;
using SistemaHospitalar.Application.UseCases;
using SistemaHospitalar.Infrastructure.Services;

namespace SistemaHospitalar;

public static class DependencyInjection
{

    public static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<CadastrarMedicoUseCase>();
        services.AddScoped<AutenticarUsuarioUseCase>();
        services.AddScoped<CadastrarPacienteUseCase>();
        services.AddScoped<ListarConsultasUseCase>();
        services.AddScoped<MarcarConsultaUseCase>();
        services.AddScoped<ListarConveniosUseCase>();
        services.AddScoped<CadastrarConvenioUseCase>();
        services.AddScoped<ListarPacientesUseCase>();
        services.AddScoped<ListarMedicosUseCase>();
        services.AddScoped<MarcarExameUseCase>();
        services.AddScoped<DetalhesPacienteUseCase>();
        services.AddScoped<DetalhesMedicoUseCase>();
        services.AddScoped<DesativarMedicoUseCase>();
        services.AddScoped<DesativarConvenioUseCase>();
        services.AddScoped<DetalhesConvenioUseCase>();
        services.AddScoped<DetalhesConsultaUseCase>();
        services.AddScoped<DesativarPacienteUseCase>();
        services.AddScoped<ListarExamesUseCase>();
        services.AddScoped<RegistrarLaudoUseCase>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMedicoRepository, Infrastructure.Database.EntityFramework.Repositories.MedicoRepository>();
        services.AddScoped<IPacienteRepository, Infrastructure.Database.EntityFramework.Repositories.PacienteRepository>();
        services.AddScoped<IUsuarioRepository, Infrastructure.Database.EntityFramework.Repositories.UsuarioRepository>();
        services.AddScoped<IConvenioRepository, Infrastructure.Database.EntityFramework.Repositories.ConvenioRepository>();
        services.AddScoped<IConsultaRepository, Infrastructure.Database.EntityFramework.Repositories.ConsultaRepository>();
        services.AddScoped<IExameRepository, Infrastructure.Database.EntityFramework.Repositories.ExameRepository>();
        services.AddScoped<ILaudoRepository, Infrastructure.Database.EntityFramework.Repositories.LaudoRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IHashService, HashService>();
        services.AddScoped<HashService>();
    }
}