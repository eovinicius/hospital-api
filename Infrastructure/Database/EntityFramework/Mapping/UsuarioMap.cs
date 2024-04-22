using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Mapping;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Username);
        builder.Property(x => x.Senha);
        builder.Property(x => x.Roles);
    }
}