using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Mapping;

public class RetornoMap : IEntityTypeConfiguration<Retorno>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Retorno> builder)
    {
        builder.ToTable("Retornos");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DataHora);
        builder.Property(x => x.Valor);
        builder.Property(x => x.ConsultaId);
        builder.Property(x => x.PacienteId);
        builder.Property(x => x.MedicoId);
        builder.Property(x => x.Status);

        builder.HasOne(x => x.Consulta).WithOne().HasForeignKey<Retorno>(x => x.ConsultaId);

        builder.HasOne(x => x.Medico).WithMany().HasForeignKey(x => x.MedicoId);

        builder.HasOne(x => x.Paciente).WithMany().HasForeignKey(x => x.PacienteId);
    }
}