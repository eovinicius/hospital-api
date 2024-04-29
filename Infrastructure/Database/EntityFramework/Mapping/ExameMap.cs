using Microsoft.EntityFrameworkCore;
using SistemaHospitalar.Domain.Entities;

namespace SistemaHospitalar.Infrastructure.Database.EntityFramework.Mapping;

public class ExameMap : IEntityTypeConfiguration<Exame>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Exame> builder)
    {
        builder.ToTable("Exames");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome);
        builder.Property(x => x.DataHora);
        builder.Property(x => x.Valor);
        builder.Property(x => x.PacienteId);
        builder.Property(x => x.MedicoId);
        builder.Property(x => x.ConsultaId);
        builder.Property(x => x.Status);

        builder.HasOne(x => x.Paciente).WithMany().HasForeignKey(x => x.PacienteId);
        builder.HasOne(x => x.Medico).WithMany().HasForeignKey(x => x.MedicoId);
        builder.HasOne(x => x.Consulta).WithMany(x => x.Exames).HasForeignKey(x => x.ConsultaId);

    }
}