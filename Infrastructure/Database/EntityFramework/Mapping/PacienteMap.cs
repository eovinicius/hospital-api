using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Mapping;
public class PacienteMap : IEntityTypeConfiguration<Paciente>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Pacientes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome);
        builder.Property(x => x.Senha);
        builder.Property(x => x.Documento);
        builder.Property(x => x.ImagemDocumento);
        builder.Property(x => x.ConvenioId);
        builder.Property(x => x.Ativo);

        builder.HasMany(x => x.Consultas).WithOne(x => x.Paciente);
    }
}