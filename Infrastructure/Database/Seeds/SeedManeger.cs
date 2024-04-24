using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Auth;
using SistemaHospitalar.Domain.Entities;
using SistemaHospitalar.Infrastructure.Services;

namespace SistemaHospitalar.Infrastructure.Database.Seeds;

public class SeedManeger
{
    public static async Task Seed(IServiceProvider services)
    {
        var context = services.GetRequiredService<DataContext>();
        var hashService = services.GetRequiredService<HashService>();

        var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Username == "admin");

        if (usuario != null)
        {
            return;
        }

        var senhaHash = hashService.Hash("admin");

        var user = new Usuario("admin", senhaHash, Roles.Admin);

        await context.Usuarios.AddAsync(user);
        await context.SaveChangesAsync();
    }
}